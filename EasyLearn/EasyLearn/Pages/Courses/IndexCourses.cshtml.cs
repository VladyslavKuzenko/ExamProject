using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyLearn.Pages.Courses
{
    public class IndexCoursesModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexCoursesModel(EasyLearn.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<Folder> Folder { get; set; }
        public Course Course { get; set; } 
        public int CourseId { get; set; }
        public async Task OnGetAsync(int courseId)
        {
            var userId = _userManager.GetUserId(User);

            Folder = await _context.Folder
                .Include(f => f.TrainingModules)
                .Where(f => f.UserId == userId && f.CourseId == courseId)
                .ToListAsync();
            Course = await _context.Course.FirstOrDefaultAsync(f => f.Id == courseId);
            Course.LastOpen=DateTime.Now;
            CourseId = courseId;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

        }
    }
}
