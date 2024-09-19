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
    public class DetailsModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;

        public DetailsModel(EasyLearn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
