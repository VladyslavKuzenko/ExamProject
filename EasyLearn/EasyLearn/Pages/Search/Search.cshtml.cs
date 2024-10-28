using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyLearn.Pages.Search
{
    public class SearchModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SearchModel(EasyLearn.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<TrainingModule> TrainingModules { get; set; } = default!;
        public IList<Folder> Folders { get; set; } = default!;
        public IList<Course> Courses { get; set; } = default!;

        public IList<object> ItemsList { get; set; } = new List<object>();

        public async Task<IActionResult> OnGet(string query)
        {
            var userId = _userManager.GetUserId(User);

            // Отримуємо папки, що належать цьому користувачеві
            Folders = await _context.Folder
                .Include(f => f.Course)
                .Where(f => f.UserId == userId)  // Фільтруємо папки за UserId
                .OrderByDescending(f => f.LastOpen)
                .ToListAsync();
            Courses = await _context.Course
                .Where(f => f.UserId == userId)
                .OrderByDescending(f => f.LastOpen)
                .ToListAsync();
            TrainingModules = await _context.TrainingModule
              .Include(t => t.Cards)
              .Include(t => t.Folder).Where(f => f.UserId == userId)  // Фільтруємо папки за UserId
              .OrderByDescending(f => f.LastOpen)
              .ToListAsync();

            foreach (var item in Folders)
            {
                if (item.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    ItemsList.Add(item);

                }
            }
            foreach (var item in Courses)
            {
                if (item.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    ItemsList.Add(item);
                }
            }
            foreach (var item in TrainingModules)
            {
                if (item.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    ItemsList.Add(item);
                }
            }

            //var allItems = new List<string> { "Item1", "Item2", "Sample", "Example" }; // Імітація даних
            //var results = allItems
            //    .Where(item => item.Contains(query, StringComparison.OrdinalIgnoreCase))
            //    .ToList();

            return Partial("_SearchResults", ItemsList);
        }
    }
}
