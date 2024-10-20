using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace EasyLearn.Pages.Folders
{
    public class IndexFolderModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        public IndexFolderModel(EasyLearn.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [BindProperty]
        public int FolderId {  get; set; } //

        [BindProperty]
        public Folder Folder { get; set; }//
        public IList<TrainingModule> TrainingModules { get; set; } = default!;//
        public TrainingModule TrainingModule { get; set; } = default!;
        [BindProperty]
        public int? SelectedTrainingModuleId { get; set; }//
        public SelectList TrainingModulesWithoutFolder { get; set; } = default!;//

        public async Task<IActionResult> OnGetAsync(int folderId)
        {
            //var userId = _userManager.GetUserId(User);
            
            
            Folder = await _context.Folder
                .Include(f => f.TrainingModules)
                .FirstOrDefaultAsync(o => o.Id == folderId);
            if (Folder == null)
            {
                return NotFound();
            }

            Folder.LastOpen=DateTime.Now;
            FolderId=folderId;


            TrainingModules = Folder.TrainingModules.ToList();
            //TrainingModule = await _context.TrainingModule
            //    .Include(t => t.Folder).Where(f => f.UserId == userId&&f.FolderId== folderId)  // Фільтруємо папки за UserId
            //    .ToListAsync();

            var modulesWithoutFolder = await _context.TrainingModule
              .Where(m => m.FolderId == null)
              .ToListAsync();
            
            TrainingModulesWithoutFolder = new SelectList(modulesWithoutFolder, "Id", "Name");
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || SelectedTrainingModuleId == null)
            {
                return RedirectToPage(new { folderId = FolderId });
            }

            var module = await _context.TrainingModule.FindAsync(SelectedTrainingModuleId);

            if (module != null && module.FolderId == null)
            {
                module.FolderId = FolderId;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(new { folderId = FolderId });
        }
        public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {
            TrainingModule=await _context.TrainingModule.FirstOrDefaultAsync(f => f.Id == id);
            
            Folder = await _context.Folder
                .Include(f=>f.TrainingModules) 
                .FirstOrDefaultAsync(f => f.TrainingModules.Contains(TrainingModule));
           
          
            //var trainingModules = Folder.TrainingModules;
            var trainingModules = await _context.TrainingModule
                .Where(t=>t.FolderId == Folder.Id)
                .ToListAsync();
            trainingModules.Remove(TrainingModule);
            Folder.TrainingModules= trainingModules;
            TrainingModule.Folder = null;
            TrainingModule.FolderId = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
              
            }
            return RedirectToPage(new { folderId = Folder.Id });

            //trainingModules.Remove();

        }
        public async Task<IActionResult> OnPostEditAsync(/*int id*/)
        {
            //// Перевірка валідності моделі
            //if (!ModelState.IsValid)
            //{
            //    return Page(); // Повертаємо ту ж сторінку з помилками
            //}

            // Встановлюємо ID курсу перед його оновленням
            var folder = await _context.Folder.FindAsync(Folder.Id);

            folder.Name = Folder.Name;
            folder.Description = Folder.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            // Переходимо на іншу сторінку або повертаємо відповідь
            return RedirectToPage(new { folderId = Folder.Id });
        }
    }
}
