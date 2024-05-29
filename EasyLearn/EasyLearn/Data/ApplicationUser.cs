using Microsoft.AspNetCore.Identity;

namespace EasyLearn.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; } = default!;


    }
}