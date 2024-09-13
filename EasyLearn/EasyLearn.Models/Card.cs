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
    public class Card
    {
        public int Id { get; set; }
        public string Term { get; set; } = default!;
        public string Definition { get; set; } = default!;
        //public byte[]? Image { get; set; }
        [JsonIgnore]
        public TrainingModule TrainingModule { get; set; } =  TrainingModule.defaultModule;
        public int TrainingModuleId { get; set; } = TrainingModule.defaultModule.Id;
        public static IEnumerable<Card> DefaultCards()
        {

            yield return new Card { Id = 1, Term = "apple", Definition = "яблуко", TrainingModuleId = TrainingModule.defaultModule.Id, TrainingModule = TrainingModule.defaultModule };
            yield return new Card { Id = 2, Term = "car", Definition = "машина", TrainingModuleId = TrainingModule.defaultModule.Id, TrainingModule = TrainingModule.defaultModule };
            yield return new Card { Id = 3, Term = "ball", Definition = "м'яч", TrainingModuleId = TrainingModule.defaultModule.Id, TrainingModule = TrainingModule.defaultModule };
        }
    }
}
