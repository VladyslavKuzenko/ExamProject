using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Identity;

namespace EasyLearn.Pages.TrainingModules
{
    public class IndexModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        public IndexModel(EasyLearn.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager; 
        }

        public IList<TrainingModule> TrainingModules { get;set; } = default!;
        public TrainingModule TrainingModule { get;set; } = default!;
        public IList<Card> Cards { get; set; } = default!;


        public async Task OnGetAsync(string searchString)
        {
            var userId = _userManager.GetUserId(User);

            TrainingModules = await _context.TrainingModule
               .Include(t => t.Folder).Where(f => f.UserId == userId)  // Фільтруємо папки за UserId
               .ToListAsync();

            TrainingModules = TrainingModules.Reverse().ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                TrainingModules = TrainingModules.Where(tm => tm.Name.Contains(searchString) || tm.Description.Contains(searchString)).ToList();
            }
        }
        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            TrainingModule = await _context.TrainingModule.FirstOrDefaultAsync(t => t.Id == id);
            Cards = await _context.Card
                .Where(c => c.TrainingModuleId == TrainingModule.Id)
                .ToListAsync();
            foreach (var card in Cards)
            {
                _context.Card.Remove(card);
            }
            _context.TrainingModule.Remove(TrainingModule);
            _context.SaveChanges();
            return RedirectToPage();

        }
    }
}
