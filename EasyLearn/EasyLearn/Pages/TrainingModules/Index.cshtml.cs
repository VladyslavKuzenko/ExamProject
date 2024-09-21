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
    public class IndexModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;

        public IndexModel(EasyLearn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TrainingModule> TrainingModule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TrainingModule = await _context.TrainingModule
                .Include(t => t.Folder).ToListAsync();
        }
    }
}
