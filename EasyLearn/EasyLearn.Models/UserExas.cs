using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearn.Models
{
    internal class UserExas
    {
        int UserId { get; set; }
        int UserWhoCanReadId { get; set; }

        Course? Course { get; set; }
        int? CourseId { get; set; }
        Folder? Folder { get; set; }
        int? FolderId { get; set; }
        TrainingModule?TrainingModule { get; set; }
        int? TrainingModuleId {  get; set; }
    }
}
