using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearn.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string? Definition {  get; set; }
        public byte[]? Image { get; set; }
       
        public static IEnumerable<Card> DefaultCards()
        {
            yield return new Card { Id = 1, Term="apple",Definition="яблуко"};
            yield return new Card { Id = 2, Term = "car", Definition = "машина" };
            yield return new Card { Id = 3, Term = "ball", Definition = "м'яч" };
        }
    }
}
