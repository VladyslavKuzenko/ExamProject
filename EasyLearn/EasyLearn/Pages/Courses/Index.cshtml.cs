using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Identity;

namespace EasyLearn.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public IndexModel(EasyLearn.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Course> Courses { get; set; } = default!;
        public Course Course { get; set; } = default!;

        public IList<Folder> Folder { get; set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            var userId = _userManager.GetUserId(User);

            // Отримуємо всі курси, що належать поточному користувачу
            Courses = await _context.Course
                .Where(c => c.UserId == userId)  // Фільтруємо курси за UserId
                .ToListAsync();

            // Перевертаємо порядок відображення курсів
            Courses = Courses.Reverse().ToList();

            // Якщо є пошуковий рядок, фільтруємо курси по імені або опису
            if (!string.IsNullOrEmpty(searchString))
            {
                Courses = Courses.Where(c => c.Name.Contains(searchString) || c.Description.Contains(searchString)).ToList();
            }
        }
        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            Course = await _context.Course.FirstOrDefaultAsync(c => c.Id == id);
            Folder= await _context.Folder
                .Where(f => f.CourseId == Course.Id)
                .ToListAsync();
            foreach (var item in Folder)
            {
                item.Course = null;
                item.CourseId = null;
            }
            _context.Course.Remove(Course);
            _context.SaveChanges();

            return RedirectToPage();

        }
    }
}
