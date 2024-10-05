using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Identity;

namespace EasyLearn.Pages.Folders
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
        public int Id { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Description { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var folder = await _context.Folder.FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);

            if (folder == null)
            {
                return NotFound();
            }

            // Заповнюємо поля для редагування
            Id = folder.Id;
            Name = folder.Name;
            Description = folder.Description;

            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = _userManager.GetUserId(User);
            var folder = await _context.Folder.FirstOrDefaultAsync(f => f.Id == Id && f.UserId == userId);

            if (folder == null)
            {
                return NotFound();
            }

            // Оновлюємо лише поля Name і Description
            folder.Name = Name;
            folder.Description = Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FolderExists(Id))
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

        private bool FolderExists(int id)
        {
            return _context.Folder.Any(e => e.Id == id);
        }
    }
}
