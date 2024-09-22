using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyLearn.Pages.TrainingModules
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Description { get; set; }
        //[BindProperty]
        //public List<Card> Cards { get; set; } = new List<Card>(); // Card data is bound here

        public IActionResult OnGet()
        {
            ViewData["FolderId"] = new SelectList(_context.Folder, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError(string.Empty, "Login is required.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var timeNow = DateTime.Now;
            var trainingModule = new TrainingModule
            {
                Name = Name,
                Description = Description,
                Create = timeNow,
                LastOpen = timeNow,
                UserId = userId,
            };

            _context.TrainingModule.Add(trainingModule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
