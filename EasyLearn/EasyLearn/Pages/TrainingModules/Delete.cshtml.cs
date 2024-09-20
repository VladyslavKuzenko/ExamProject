using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EasyLearn.Data;
using EasyLearn.Models;

namespace EasyLearn.Pages.TrainingModules
{
    public class DeleteModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;

        public DeleteModel(EasyLearn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrainingModule TrainingModule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingmodule = await _context.TrainingModule.FirstOrDefaultAsync(m => m.Id == id);

            if (trainingmodule == null)
            {
                return NotFound();
            }
            else
            {
                TrainingModule = trainingmodule;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingmodule = await _context.TrainingModule.FindAsync(id);
            if (trainingmodule != null)
            {
                TrainingModule = trainingmodule;
                _context.TrainingModule.Remove(TrainingModule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
