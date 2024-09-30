using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyLearn.Models
{
    public class UserExas
    {
        public int Id { get; set; }
        public string UserId { get; set; } = default!;
        public string UserWhoCanReadId { get; set; } = default!;

        [JsonIgnore]
        public Course? Course { get; set; }
        public int? CourseId { get; set; }
        [JsonIgnore]
        public Folder? Folder { get; set; }
        public int? FolderId { get; set; }
        [JsonIgnore]
        public TrainingModule?TrainingModule { get; set; }
        public int? TrainingModuleId {  get; set; }
    }
}
