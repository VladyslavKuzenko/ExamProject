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
            return Page();
        }

        [BindProperty]
        public Folder Folder { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Перевіряємо, чи користувач залогований
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login");
            }
            if (_userManager == null)
            {
                throw new Exception("UserManager is not available.");
            }


            // Отримуємо ідентифікатор користувача
            var userId = _userManager.GetUserId(User);
            Console.WriteLine($"UserId: {userId}");

            if (string.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError(string.Empty, "UserId is not available.");
                return Page();
            }

            Folder.UserId = userId;  // Встановлюємо UserId до моделі

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return Page();
            }


            var timeNow = DateTime.Now;
            Folder.Create = timeNow;
            Folder.LastOpen = timeNow;
            Folder.IsLearned = false;

            _context.Folder.Add(Folder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}