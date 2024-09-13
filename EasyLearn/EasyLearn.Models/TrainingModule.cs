using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyLearn.Models
{
    public class TrainingModule
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        //[JsonIgnore]
        //public IEnumerable<Card>? Cards { get; set; } 
        
        public DateTime Create {  get; set; }
        public DateTime LastOpen { get; set; }
        public bool IsLearned { get; set; } = false;

        //[JsonIgnore]
        public IEnumerable<Folder>? Folders { get; set; }
        //public int FolderId { get; set; }

        public string UserId { get; set; } = default!;

        public static TrainingModule defaultModule= new TrainingModule { Id = 1, Name = "Something like a1", Create = DateTime.Now, LastOpen = DateTime.Now };
        public static IEnumerable<TrainingModule> DefaultTrainingModules()
        {

            yield return defaultModule;
        }
    }
}
