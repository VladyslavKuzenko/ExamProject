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

namespace EasyLearn.Resources.Pages.Folders
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

        public IList<Folder> Folder { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //Folder = await _context.Folder
            //    .Include(f => f.Course).ToListAsync();

            //for (int i = 0; i < Folder.Count; i++)
            //{
            //     foreach (var el in _context.TrainingModule)
            //    {
            //        if (el.FolderId == Folder[i].Id)
            //        {
            //            if (Folder[i].TrainingModules == null)
            //            {
            //                Folder[i].TrainingModules = new List<TrainingModule>();
            //            }
            //            Folder[i].TrainingModules.Append(el);
            //        }
            //    }
            //}

            // Отримуємо ідентифікатор користувача
            var userId = _userManager.GetUserId(User);

            // Отримуємо папки, що належать цьому користувачеві
            Folder = await _context.Folder
                .Include(f => f.Course)
                .Where(f => f.UserId == userId)  // Фільтруємо папки за UserId
                .ToListAsync();

            // Додаємо тренінги (TrainingModule) до папок
            for (int i = 0; i < Folder.Count; i++)
            {
                foreach (var el in _context.TrainingModule)
                {
                    if (el.FolderId == Folder[i].Id)
                    {
                        if (Folder[i].TrainingModules == null)
                        {
                            Folder[i].TrainingModules = new List<TrainingModule>();
                        }
                        Folder[i].TrainingModules.Append(el);
                    }
                }
            }

        }
    }
}
