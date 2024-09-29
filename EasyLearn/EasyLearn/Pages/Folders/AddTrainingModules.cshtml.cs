using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyLearn.Data;
using EasyLearn.Models;

namespace EasyLearn.Pages.Folders
{
    public class AddTrainingModulesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AddTrainingModulesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int FolderId { get; set; }

        public Folder Folder { get; set; } = default!;

        [BindProperty]
        public int? SelectedTrainingModuleId { get; set; }

        public List<TrainingModule> TrainingModulesInFolder { get; set; } = new List<TrainingModule>();

        public SelectList TrainingModulesWithoutFolder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int folderId)
        {
            Folder = await _context.Folder
                .Include(f => f.TrainingModules)
                .FirstOrDefaultAsync(f => f.Id == folderId);

            if (Folder == null)
            {
                return NotFound();
            }

            FolderId = folderId;

            TrainingModulesInFolder = Folder.TrainingModules.ToList();

            var modulesWithoutFolder = await _context.TrainingModule
                .Where(m => m.FolderId == null)
                .ToListAsync();

            TrainingModulesWithoutFolder = new SelectList(modulesWithoutFolder, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || SelectedTrainingModuleId == null)
            {
                return RedirectToPage(new { folderId = FolderId });
            }

            var module = await _context.TrainingModule.FindAsync(SelectedTrainingModuleId);

            if (module != null && module.FolderId == null)
            {
                module.FolderId = FolderId;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(new { folderId = FolderId });
        }
    }
}
