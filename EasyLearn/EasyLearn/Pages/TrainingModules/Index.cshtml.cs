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

        public IList<TrainingModule> TrainingModule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            TrainingModule = await _context.TrainingModule
                .Include(t => t.Folder).Where(f => f.UserId == userId)  // Фільтруємо папки за UserId
                .ToListAsync();
        }
    }
}
