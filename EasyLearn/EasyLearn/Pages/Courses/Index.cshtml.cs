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

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            var userId = _userManager.GetUserId(User);

            // Отримуємо всі курси, що належать поточному користувачу
            Course = await _context.Course
                .Where(c => c.UserId == userId)  // Фільтруємо курси за UserId
                .ToListAsync();

            // Перевертаємо порядок відображення курсів
            Course = Course.Reverse().ToList();

            // Якщо є пошуковий рядок, фільтруємо курси по імені або опису
            if (!string.IsNullOrEmpty(searchString))
            {
                Course = Course.Where(c => c.Name.Contains(searchString) || c.Description.Contains(searchString)).ToList();
            }
        }
    }
}
