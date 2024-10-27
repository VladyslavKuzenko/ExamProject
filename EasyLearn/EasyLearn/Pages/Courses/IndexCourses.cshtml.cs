using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

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
        [BindProperty]
        public int? SelectedFolderId { get; set; }
        public IList<Folder> Folders { get; set; }
        public Folder Folder { get; set; } = default!;
        public SelectList UnassignedFolders { get; set; } = default!;
        //public List<Folder> UnassignedFolders { get; set; } = new List<Folder>();
        [BindProperty]
        public Course Course { get; set; }
        [BindProperty]
        public int CourseId { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; } 
        public async Task<IActionResult> OnGetAsync(int courseId)
        {
            //if (courseId == null)
            //{
            //    return NotFound();
            //}
            var userId = _userManager.GetUserId(User);

            Course = await _context.Course
                .Include(c => c.Folders)
                .FirstOrDefaultAsync(f => f.Id == courseId);
            if (Course == null)
            {
                return NotFound();
            }
            Course.LastOpen = DateTime.Now;
            CourseId = courseId;

            Folders = Course.Folders.ToList();
            var foldersWithoutCourse = await _context.Folder
                .Where(m => m.CourseId == null)
                .ToListAsync();
            UnassignedFolders = new SelectList(foldersWithoutCourse, "Id", "Name");


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Page();

        }
        public async Task<IActionResult> OnPostAsync(int? courseId)
        {
            if (courseId == null || SelectedFolderId == null)
            {
                return RedirectToPage(new { courseId = CourseId });
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
        public async Task<IActionResult> OnGetRemoveFolderAsync(int? id)
        {
            Folder = await _context.Folder.FirstOrDefaultAsync(f => f.Id == id);
            Course = await _context.Course
                .Include(c => c.Folders)
                .FirstOrDefaultAsync(c => c.Folders.Contains(Folder));

            var folder=await _context.Folder
                .Where(f => f.CourseId == Course.Id)
                .ToListAsync();
            folder.Remove(Folder);
            Course.Folders = folder;
            CourseId = Course.Id;
            Folder.Course = null;
            Folder.CourseId = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage(new { courseId = Course.Id });
        }
        public async Task<IActionResult> OnGetDeleteCourseAsync(int id)
        {
            Course = await _context.Course.FirstOrDefaultAsync(c => c.Id == id);
            Folders = await _context.Folder
                .Where(f => f.CourseId == Course.Id)
                .ToListAsync();
            foreach (var item in Folders)
            {
                item.Course = null;
                item.CourseId = null;
            }
            _context.Course.Remove(Course);
            _context.SaveChanges();

            return RedirectToPage("/Courses/Index");

        }
        public async Task<IActionResult> OnPostEditAsync(/*int id*/)
        {
            //// Перевірка валідності моделі
            //if (!ModelState.IsValid)
            //{
            //    return Page(); // Повертаємо ту ж сторінку з помилками
            //}

            // Встановлюємо ID курсу перед його оновленням
            var course = await _context.Course.FindAsync(Course.Id);

            course.Name = Course.Name;
            course.Description = Course.Description;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            // Переходимо на іншу сторінку або повертаємо відповідь
            return RedirectToPage(new { courseId = Course.Id });
        }


    }
}
