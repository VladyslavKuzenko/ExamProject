using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EasyLearn.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly EasyLearn.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(EasyLearn.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<TrainingModule> TrainingModules { get; set; } = default!;
        public IList<Folder> Folders { get; set; } = default!;
        public IList<Course> Courses { get; set; } = default!;

        public IList<object> LastOpenItemsList { get; set; } = new List<object>();
        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);

            // Отримуємо папки, що належать цьому користувачеві
            Folders = await _context.Folder
                .Include(f => f.Course)
                .Where(f => f.UserId == userId)  // Фільтруємо папки за UserId
                .OrderByDescending(f => f.LastOpen)
                .ToListAsync();

            // Додаємо тренінги (TrainingModule) до папок
            for (int i = 0; i < Folders.Count; i++)
            {
                foreach (var el in _context.TrainingModule)
                {
                    if (el.FolderId == Folders[i].Id)
                    {
                        if (Folders[i].TrainingModules == null)
                        {
                            Folders[i].TrainingModules = new List<TrainingModule>();
                        }
                        Folders[i].TrainingModules.Append(el);
                    }
                }
            }


            Courses = await _context.Course
                .Where(f => f.UserId == userId)
                .OrderByDescending(f => f.LastOpen)
                .ToListAsync();

            for (int i = 0; i < Courses.Count; i++)
            {
                foreach (var el in _context.Folder)
                {
                    if (el.CourseId == Courses[i].Id)
                    {
                        if (Courses[i].Folders == null)
                        {
                            Courses[i].Folders = new List<Folder>();
                        }
                        Courses[i].Folders.Append(el);
                    }
                }
            }

            TrainingModules = await _context.TrainingModule
                .Include(t => t.Folder).Where(f => f.UserId == userId)  // Фільтруємо папки за UserId
                .OrderByDescending(f => f.LastOpen)
                .ToListAsync();


            var TrainingModulesTemp = TrainingModules.ToList();
            var CoursesTemp = Courses.ToList();
            var FoldersTemp = Folders.ToList();

            for (int i = 0; i < 6; i++)
            {
                //object minItem = TrainingModulesTemp[i];
                //var minTime = TrainingModulesTemp[i].LastOpen;
                object minItem;
                var minTime=DateTime.MinValue;

                if (TrainingModulesTemp[0]!=null)
                {
                    minItem = TrainingModulesTemp[0];
                    minTime = TrainingModulesTemp[0].LastOpen;
                }
                else if (FoldersTemp[0]!=null)
                {
                    minItem = FoldersTemp[0];
                    minTime = FoldersTemp[0].LastOpen;
                }
                else if (CoursesTemp[0] != null)
                {
                    minItem = CoursesTemp[0];
                    minTime = CoursesTemp[0].LastOpen;
                }
                else
                {
                    minItem = null;
                }

                if (minItem != null)
                {
                    int j = 0;
                    foreach (var item in TrainingModulesTemp)
                    {
                        if (j<6)
                        {
                            if (item.LastOpen > minTime)
                            {
                                minTime = item.LastOpen;
                                minItem = item;
                            }
                        }
                        else
                        {
                            break;
                        }
                        j++;
                    }

                    j = 0;
                    foreach (var item in FoldersTemp)
                    {
                        if (j < 6)
                        {
                            if (item.LastOpen > minTime)
                            {
                                minTime = item.LastOpen;
                                minItem = item;
                            }
                        }
                        else
                        {
                            break;
                        }
                        j++;
                    }

                    j = 0;
                    foreach (var item in CoursesTemp)
                    {
                        if (j < 6)
                        {
                            if (item.LastOpen > minTime)
                            {
                                minTime = item.LastOpen;
                                minItem = item;
                            }
                        }
                        else
                        {
                            break;
                        }
                        j++;
                    }


                    LastOpenItemsList.Add(minItem);
                    if (minItem is TrainingModule)
                    {
                        //var it = minItem as TrainingModule;
                        TrainingModulesTemp.Remove(minItem as TrainingModule);
                    }else if (minItem is Folder)
                    {
                        FoldersTemp.Remove(minItem as Folder);
                    }else {
                        CoursesTemp.Remove(minItem as Course);
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
