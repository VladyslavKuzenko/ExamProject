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
        public TrainingModule? TrainingModule { get; set; }  // Навігаційна властивість має бути nullable, щоб уникнути конфліктів при сідінгу
        public int TrainingModuleId { get; set; }  // Зовнішній ключ

        public static IEnumerable<Card> DefaultCards()
        {
            yield return new Card { Id = 1, Term = "apple", Definition = "яблуко", TrainingModuleId = 1 };
            yield return new Card { Id = 2, Term = "car", Definition = "машина", TrainingModuleId = 1 };
            yield return new Card { Id = 3, Term = "ball", Definition = "м'яч", TrainingModuleId = 1 };
        }
    }

}
