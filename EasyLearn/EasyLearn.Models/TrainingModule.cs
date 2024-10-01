using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime Create { get; set; }
        public DateTime LastOpen { get; set; }
        public bool IsLearned { get; set; } = false;

        [JsonIgnore]
        public List<Card> Cards { get; set; } = new List<Card>();
        //public IEnumerable<Card> Cards { get; set; } = Enumerable.Empty<Card>();


        public Folder? Folder { get; set; }
        public int? FolderId { get; set; }
        public string UserId { get; set; } = default!;

        public static IEnumerable<TrainingModule> DefaultTrainingModules()
        {
            yield return new TrainingModule { Id = 1, Name = "C# Basics", Create = DateTime.Now, LastOpen = DateTime.Now };
            yield return new TrainingModule { Id = 2, Name = "Advanced C#", Create = DateTime.Now, LastOpen = DateTime.Now };
        }
    }

}
