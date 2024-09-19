using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EasyLearn.Data;
using EasyLearn.Models;

namespace EasyLearn.Resources.Pages.Folders
{
    public class IndexModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;

        public IndexModel(EasyLearn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Folder> Folder { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Folder = await _context.Folder
                .Include(f => f.Course).ToListAsync();

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
