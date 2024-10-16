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

        public IList<TrainingModule> TrainingModule { get; set; } = default!;

        [BindProperty]
        public int? SelectedTrainingModuleId { get; set; }
        public SelectList TrainingModulesWithoutFolder { get; set; } = default!;

        public Folder Folder { get; set; }

        public int FolderId {  get; set; } 
        public async Task OnGetAsync(int folderId)
        {
            var userId = _userManager.GetUserId(User);
            TrainingModule = await _context.TrainingModule
                .Include(t => t.Folder).Where(f => f.UserId == userId&&f.FolderId== folderId)  // Фільтруємо папки за UserId
                .ToListAsync();
            Folder = await _context.Folder.FirstOrDefaultAsync(o => o.Id == folderId);
            Folder.LastOpen=DateTime.Now;
            FolderId=folderId;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
        }
        
    }
}
