using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyLearn.Pages.Courses
{
    public class AssignFoldersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AssignFoldersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int SelectedFolderId { get; set; }

        public Course Course { get; set; } = default!;
        public List<Folder> UnassignedFolders { get; set; } = new List<Folder>();

        public async Task<IActionResult> OnGetAsync(int? courseId)
        {
            if (courseId == null)
            {
                return NotFound();
            }

            Course = await _context.Course
                                   .Include(c => c.Folders)
                                   .FirstOrDefaultAsync(c => c.Id == courseId);

            if (Course == null)
            {
                return NotFound();
            }

            UnassignedFolders = await _context.Folder
                                              .Where(f => f.CourseId == null)
                                              .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? courseId)
        {
            if (courseId == null || SelectedFolderId == 0)
            {
                return Page();
            }

            var course = await _context.Course.FindAsync(courseId);
            var folder = await _context.Folder.FindAsync(SelectedFolderId);

            if (course == null || folder == null)
            {
                return NotFound();
            }

            folder.CourseId = course.Id;
            _context.Attach(folder).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage(new { courseId = course.Id });
        }
    }
}
