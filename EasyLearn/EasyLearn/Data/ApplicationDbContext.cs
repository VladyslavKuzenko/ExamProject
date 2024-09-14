//using EasyLearn.Areas.Identity.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EasyLearn.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EasyLearn.Models.Card> Card { get; set; } = default!;
        public DbSet<EasyLearn.Models.TrainingModule> TrainingModule { get; set; } = default!;
        public DbSet<EasyLearn.Models.Folder> Folder { get; set; } = default!;
        public DbSet<EasyLearn.Models.Course> Course { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Course>()
            .HasOne<ApplicationUser>()  
            .WithMany()      
            .HasForeignKey(c => c.UserId)  
            .HasConstraintName("FK_Course_User");

            builder.Entity<Folder>()
               .HasOne<ApplicationUser>()        
               .WithMany()                       
               .HasForeignKey(f => f.UserId)     
               .HasConstraintName("FK_Folder_User");

            builder.Entity<TrainingModule>()
               .HasOne<ApplicationUser>()       
               .WithMany()                      
               .HasForeignKey(tm => tm.UserId)  
               .HasConstraintName("FK_TrainingModule_User");
            // Зовнішні ключі для UserId та UserWhoCanReadId
            builder.Entity<UserExas>()
                .HasOne<ApplicationUser>()
                .WithMany()                        
                .HasForeignKey(ue => ue.UserId)    
                .HasConstraintName("FK_UserExas_User");

            builder.Entity<UserExas>()
                .HasOne<ApplicationUser>()                 
                .WithMany()                                
                .HasForeignKey(ue => ue.UserWhoCanReadId)  
                .HasConstraintName("FK_UserExas_UserWhoCanRead");






        }
    }
}
