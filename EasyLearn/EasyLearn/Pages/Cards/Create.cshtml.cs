using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EasyLearn.Data;
using EasyLearn.Models;

namespace EasyLearn.Pages.Cards
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Term { get; set; } = default!;

        [BindProperty]
        public string Definition { get; set; } = default!;

        [BindProperty]
        public int TrainingModuleId { get; set; }

        public IActionResult OnGet(int trainingModuleId)
        {
            TrainingModuleId = trainingModuleId; // Set the training module ID from the route
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var card = new Card
            {
                Term = Term,
                Definition = Definition,
                TrainingModuleId = TrainingModuleId
            };

            _context.Card.Add(card);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { trainingModuleId = TrainingModuleId });
        }
    }
}
