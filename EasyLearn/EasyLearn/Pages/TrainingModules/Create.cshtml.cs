using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Authorization;

namespace EasyLearn.Pages.TrainingModules
{
    [Authorize]
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

        [BindProperty]
        public List<CardInputModel> Cards { get; set; } = new List<CardInputModel>();

        public class CardInputModel
        {
            public string Term { get; set; }
            public string Definition { get; set; }
        }

        public IActionResult OnGet()
        {
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

            var trainingModule = new TrainingModule
            {
                Name = Name,
                Description = Description,
                Create = DateTime.Now,
                LastOpen = DateTime.Now,
                UserId = userId
            };

            _context.TrainingModule.Add(trainingModule);
            await _context.SaveChangesAsync();

            foreach (var cardInput in Cards)
            {
                var card = new Card
                {
                    Term = cardInput.Term,
                    Definition = cardInput.Definition,
                    TrainingModuleId = trainingModule.Id
                };

                // Додаємо картку до бази даних
                _context.Card.Add(card);
                trainingModule.Cards.Add(card);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

    }
}
