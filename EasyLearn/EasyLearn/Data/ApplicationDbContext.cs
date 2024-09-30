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
                .HasConstraintName("FK_UserExas_UserWhoCanRead")
                .OnDelete(DeleteBehavior.Restrict);



            builder.Entity<ApplicationUser>().HasData(
         new ApplicationUser
         {
             Id = "user123",
             UserName = "testuser1",
             NormalizedUserName = "TESTUSER1",
             Email = "testuser1@example.com",
             NormalizedEmail = "TESTUSER1@EXAMPLE.COM",
             EmailConfirmed = true,
             PasswordHash = "AQAAAAEAACcQAAAAEMJP9v5ZC",
             Name = "testUser1"
         },
         new ApplicationUser
         {
             Id = "user456",
             UserName = "testuser2",
             NormalizedUserName = "TESTUSER2",
             Email = "testuser2@example.com",
             NormalizedEmail = "TESTUSER2@EXAMPLE.COM",
             EmailConfirmed = true,
             PasswordHash = "AQAAAAEAACcQAAAAEMJP9v5ZC",
             Name = "testUser2"
         }
     );

            // Додай курси
            builder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Name = "C# for Beginners",
                    Description = "Basic course for C# programming",
                    UserId = "user123",
                    Create = DateTime.Now,
                    LastOpen = DateTime.Now,
                    IsLearned = false
                },
                new Course
                {
                    Id = 2,
                    Name = "Advanced C#",
                    Description = "Advanced topics in C#",
                    UserId = "user456",
                    Create = DateTime.Now,
                    LastOpen = DateTime.Now,
                    IsLearned = false
                }
            );

            // Додай папки
            builder.Entity<Folder>().HasData(
                new Folder
                {
                    Id = 1,
                    Name = "Introduction",
                    Description = "Introductory folder",
                    UserId = "user123",
                    Create = DateTime.Now,
                    LastOpen = DateTime.Now,
                    IsLearned = false,
                    CourseId = 1
                },
                new Folder
                {
                    Id = 2,
                    Name = "Advanced Topics",
                    Description = "Folder with advanced topics",
                    UserId = "user456",
                    Create = DateTime.Now,
                    LastOpen = DateTime.Now,
                    IsLearned = false,
                    CourseId = 2
                }
            );

            // Додай тренувальні модулі
            builder.Entity<TrainingModule>().HasData(
                new TrainingModule
                {
                    Id = 1,
                    Name = "C# Basics",
                    Description = "Learn the basics of C#",
                    UserId = "user123",
                    Create = DateTime.Now,
                    LastOpen = DateTime.Now,
                    IsLearned = false,
                    FolderId = 1
                },
                new TrainingModule
                {
                    Id = 2,
                    Name = "Advanced C# Features",
                    Description = "Learn advanced C# features",
                    UserId = "user456",
                    Create = DateTime.Now,
                    LastOpen = DateTime.Now,
                    IsLearned = false,
                    FolderId = 2
                }
            );

            // Додай картки
            builder.Entity<Card>().HasData(
                new Card { Id = 1, Term = "Class", Definition = "A blueprint for creating objects", TrainingModuleId = 1 },
                new Card { Id = 2, Term = "Object", Definition = "An instance of a class", TrainingModuleId = 1 },
                new Card { Id = 3, Term = "Inheritance", Definition = "The process of acquiring properties and behaviors from a parent class", TrainingModuleId = 2 }
            );


        }
    }
}
