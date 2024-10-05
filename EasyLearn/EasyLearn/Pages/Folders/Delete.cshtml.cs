using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EasyLearn.Data;
using EasyLearn.Models;

namespace EasyLearn.Pages.Folders
{
    public class DeleteModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;

        public DeleteModel(EasyLearn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Folder Folder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var folder = await _context.Folder.FirstOrDefaultAsync(m => m.Id == id);

            if (folder == null)
            {
                return NotFound();
            }
            else
            {
                Folder = folder;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var folder = await _context.Folder.FindAsync(id);
            if (folder != null)
            {
                Folder = folder;
                _context.Folder.Remove(Folder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
