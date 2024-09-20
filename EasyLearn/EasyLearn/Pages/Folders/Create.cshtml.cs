using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EasyLearn.Resources.Pages.Folders
{
    
    public class CreateModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CreateModel(EasyLearn.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name");
            //this.Folder = new Folder { UserId = _userManager.GetUserId(User) };
            return Page();
        }

        //[BindProperty]
        //public Folder Folder { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Description { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            


            // Отримуємо ідентифікатор користувача
            var userId = _userManager.GetUserId(User);
            
            if (string.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError(string.Empty, "Login firstly.");
                return Page();
            }

            var timeNow = DateTime.Now;
            var folder = new Folder { UserId = userId, Name = this.Name, Description = this.Description };
            folder.Create = timeNow;
            folder.LastOpen = timeNow;
            folder.IsLearned = false;

            

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return Page();
            }


            

            _context.Folder.Add(folder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}