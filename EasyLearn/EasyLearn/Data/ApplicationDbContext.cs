
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EasyLearn.Models;

namespace EasyLearn.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EasyLearn.Models.Card> Card { get; set; } = default!;
        public DbSet<EasyLearn.Models.TrainingModule> TrainingModule { get; set; } = default!;
        public DbSet<EasyLearn.Models.Folder> Folder { get; set; } = default!;
        public DbSet<EasyLearn.Models.Course> Course { get; set; } = default!;
        public DbSet<EasyLearn.Models.User> User { get; set; } = default!;
    }
}
