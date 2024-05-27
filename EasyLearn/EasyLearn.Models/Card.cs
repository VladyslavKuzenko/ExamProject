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
    }
}
