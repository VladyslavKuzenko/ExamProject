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

        public async Task OnGetAsync()
        {
            // Отримуємо ідентифікатор користувача
            var userId = _userManager.GetUserId(User);

            // Отримуємо папки, що належать цьому користувачеві
            Course = await _context.Course
                .Where(f => f.UserId == userId)  
                .ToListAsync();

            // Додаємо тренінги (TrainingModule) до папок
            for (int i = 0; i < Course.Count; i++)
            {
                foreach (var el in _context.Folder)
                {
                    if (el.CourseId == Course[i].Id)
                    {
                        if (Course[i].Folders == null)
                        {
                            Course[i].Folders = new List<Folder>();
                        }
                        Course[i].Folders.Append(el);
                    }
                }
            }
        }
    }
}
