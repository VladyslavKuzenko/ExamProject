using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearn.Models
{
    internal class TrainingModule
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Card> Cards { get; set; }
        public DateTime Create {  get; set; }
        public DateTime LastOpen { get; set; }
        public bool IsLearned { get; set; } = false;
    }
}
