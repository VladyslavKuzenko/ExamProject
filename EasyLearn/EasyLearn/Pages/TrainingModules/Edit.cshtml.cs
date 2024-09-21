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

namespace EasyLearn.Pages.TrainingModules
{
    public class EditModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;

        public EditModel(EasyLearn.Data.ApplicationDbContext context)
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

            var trainingmodule =  await _context.TrainingModule.FirstOrDefaultAsync(m => m.Id == id);
            if (trainingmodule == null)
            {
                return NotFound();
            }
            TrainingModule = trainingmodule;
           ViewData["FolderId"] = new SelectList(_context.Folder, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TrainingModule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingModuleExists(TrainingModule.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TrainingModuleExists(int id)
        {
            return _context.TrainingModule.Any(e => e.Id == id);
        }
    }
}
