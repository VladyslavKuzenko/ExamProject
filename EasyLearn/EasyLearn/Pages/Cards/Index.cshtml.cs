using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EasyLearn.Data;
using EasyLearn.Models;

namespace EasyLearn.Pages.Cards
{
    public class IndexModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;

        public IndexModel(EasyLearn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Card> Card { get;set; } = default!;
        public int TrainingModuleId { get; set; }

        public TrainingModule TrainingModule { get; set; }

        public async Task OnGetAsync(int trainingModuleId)
        {
            TrainingModuleId = trainingModuleId;
            Card = await _context.Card
             .Where(c => c.TrainingModuleId == trainingModuleId)
             .ToListAsync();
            TrainingModule= await _context.TrainingModule.FirstOrDefaultAsync(o=>o.Id == trainingModuleId);
            TrainingModule.LastOpen= DateTime.Now;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
        }
    }
}
