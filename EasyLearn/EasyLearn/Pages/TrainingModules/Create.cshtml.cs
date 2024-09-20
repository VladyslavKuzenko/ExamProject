using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EasyLearn.Data;
using EasyLearn.Models;

namespace EasyLearn.Pages.TrainingModules
{
    public class CreateModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;

        public CreateModel(EasyLearn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FolderId"] = new SelectList(_context.Folder, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public TrainingModule TrainingModule { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TrainingModule.Add(TrainingModule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
