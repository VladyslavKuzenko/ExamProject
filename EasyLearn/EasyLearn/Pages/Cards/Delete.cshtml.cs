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
    public class DeleteModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;

        public DeleteModel(EasyLearn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Card Card { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Card.FirstOrDefaultAsync(m => m.Id == id);

            if (card == null)
            {
                return NotFound();
            }
            else
            {
                Card = card;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Card.FindAsync(id);
            if (card != null)
            {
                Card = card;
                _context.Card.Remove(Card);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
