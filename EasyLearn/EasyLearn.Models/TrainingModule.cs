using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearn.Models
{
    public class TrainingModule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Card> Cards { get; set; }
        public DateTime Create {  get; set; }
        public DateTime LastOpen { get; set; }
        public bool IsLearned { get; set; } = false;

        public static IEnumerable<TrainingModule> DefaultTrainingModules()
        {
            IEnumerable<Card> cards = Card.DefaultCards();
            
            yield return new TrainingModule { Id = 1, Name = "Something like a1", Cards = new List<Card> { cards.ElementAt(0), cards.ElementAt(1), cards.ElementAt(3) } ,Create=DateTime.Now,LastOpen=DateTime.Now };
        }
    }
}
