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
      

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var userId = _userManager.GetUserId(User);
            var module = await _context.TrainingModule.FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);
            if (module == null) return NotFound();

            Id = module.Id;
            Name = module.Name;
            Description = module.Description;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var userId = _userManager.GetUserId(User);
            var moduleToUpdate = await _context.TrainingModule.FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);

            if (moduleToUpdate == null) return NotFound();

            moduleToUpdate.Name = Name;
            moduleToUpdate.Description = Description;

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
