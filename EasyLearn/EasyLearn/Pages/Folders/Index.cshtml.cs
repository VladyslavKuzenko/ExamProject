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

namespace EasyLearn.Pages.Folders
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

        public IList<Folder> Folders { get;set; } = default!;
        public Folder Folder { get; set; } = default!;

        public IList<TrainingModule> TrainingModules { get; set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            var userId = _userManager.GetUserId(User);

            // Отримуємо всі папки, що належать поточному користувачу
            Folders = await _context.Folder
                .Where(f => f.UserId == userId)  // Фільтруємо папки за UserId
                .ToListAsync();

            // Перевертаємо порядок відображення папок
            Folders = Folders.Reverse().ToList();

            // Якщо є пошуковий рядок, фільтруємо папки по імені або опису
            if (!string.IsNullOrEmpty(searchString))
            {
                Folders = Folders.Where(f => f.Name.Contains(searchString) || f.Description.Contains(searchString)).ToList();
            }
        }
        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            Folder = await _context.Folder.FirstOrDefaultAsync(c => c.Id == id);
            TrainingModules = await _context.TrainingModule
                .Where(f => f.FolderId == Folder.Id)
                .ToListAsync();
            foreach (var item in TrainingModules)
            {
                item.Folder = null;
                item.FolderId = null;
            }
            _context.Folder.Remove(Folder);
            _context.SaveChanges();

            return RedirectToPage();

        }
    }
}
