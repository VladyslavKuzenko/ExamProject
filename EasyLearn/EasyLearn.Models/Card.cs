using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyLearn.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Term { get; set; } = default!;
        public string? Definition {  get; set; }
        public byte[]? Image { get; set; }
        [JsonIgnore]
        public TrainingModule? TrainingModule { get; set; }
        public int TrainingModuleId { get; set; }
        public static IEnumerable<Card> DefaultCards()
        {
            yield return new Card { Id = 1, Term="apple",Definition="яблуко", TrainingModuleId=TrainingModule.defaultModule.Id};
            yield return new Card { Id = 2, Term = "car", Definition = "машина" , TrainingModuleId = TrainingModule.defaultModule.Id };
            yield return new Card { Id = 3, Term = "ball", Definition = "м'яч", TrainingModuleId = TrainingModule.defaultModule.Id };
        }
    }
}
