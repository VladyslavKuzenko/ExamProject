using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearn.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Login { get; set; } = default!;
        public string Password { get; set; } = default!;
        public byte[]? Avatar { get; set; }
    }
}
