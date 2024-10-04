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
using Microsoft.AspNetCore.Identity;
using static EasyLearn.Pages.TrainingModules.CreateModel;

namespace EasyLearn.Pages.TrainingModules
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [BindProperty]
        public int Id { get; set;}

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public List<CardInputModel> Cards { get; set; }

        public class CardInputModel
        {
            public string Term { get; set; }
            public string Definition { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var userId = _userManager.GetUserId(User);
            var module = await _context.TrainingModule.Include(o => o.Cards).FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);
            if (module == null) return NotFound();

            Id = module.Id;
            Name = module.Name;
            Description = module.Description;
            Cards=new List<CardInputModel>();
            for (int i = 0; i < module.Cards.Count; i++)
            {
                Cards.Add(new CardInputModel { Term = module.Cards[i].Term, Definition = module.Cards[i].Definition });
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var userId = _userManager.GetUserId(User);
            var moduleToUpdate = await _context.TrainingModule.Include(o => o.Cards).FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);


            if (moduleToUpdate == null) return NotFound();

            moduleToUpdate.Name = Name;
            moduleToUpdate.Description = Description;


            if (Cards.Count>moduleToUpdate.Cards.Count)
            {
                for (int i = 0; i < moduleToUpdate.Cards.Count; i++)
                {
                    moduleToUpdate.Cards[i].Term = Cards[i].Term;
                    moduleToUpdate.Cards[i].Definition = Cards[i].Definition;
                }
                for (int i = moduleToUpdate.Cards.Count; i < Cards.Count; i++)
                {
                    var card = new Card
                    {
                        Term = Cards[i].Term,
                        Definition = Cards[i].Definition,
                        TrainingModuleId = moduleToUpdate.Id
                    };

                    // Додаємо картку до бази даних
                    _context.Card.Add(card);
                    moduleToUpdate.Cards.Add(card);
                }
            }
            else 
            {
                for (int i = 0; i < moduleToUpdate.Cards.Count; i++)
                {
                    moduleToUpdate.Cards[i].Term = Cards[i].Term;
                    moduleToUpdate.Cards[i].Definition = Cards[i].Definition;
                }
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return RedirectToPage("./Index");
        }
        private bool ModuleExists(int id)
        {
            return _context.TrainingModule.Any(e => e.Id == id);
        }
    }

}
