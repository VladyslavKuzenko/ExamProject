using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EasyLearn.Pages.Courses
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(EasyLearn.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public string Name { get; set; } = default!;
        [BindProperty]
        public string? Description { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Отримуємо ідентифікатор користувача
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError(string.Empty, "Login firstly.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var timeNow = DateTime.Now;

            // Створюємо новий курс і прив'язуємо дані
            var course = new Course
            {
                Name = this.Name,
                Description = this.Description,
                UserId = userId,
                Create = timeNow,
                LastOpen = timeNow,
                IsLearned = false
            };

            _context.Course.Add(course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnGetCreateAsync()
        {
            return Page();
        }
    }
}
