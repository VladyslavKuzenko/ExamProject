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
    public class DetailsModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;

        public DetailsModel(EasyLearn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
