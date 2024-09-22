using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyLearn.Data;
using EasyLearn.Models;

namespace EasyLearn.Pages.Cards
{
    public class EditModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;

        public EditModel(EasyLearn.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public int Id { get; set; } 

        [BindProperty]
        public string Term { get; set; }

        [BindProperty]
        public string Definition { get; set; } = default!;


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
            Id = card.Id;
            Term = card.Term;
            Definition = card.Definition;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var card = await _context.Card.FirstOrDefaultAsync(m => m.Id == Id);
            if (card == null)
            {
                return NotFound();
            }
            card.Term = Term;   
            card.Definition = Definition;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(card.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { trainingModuleId = card.TrainingModuleId });
        }

        private bool CardExists(int id)
        {
            return _context.Card.Any(e => e.Id == id);
        }
    }
}
