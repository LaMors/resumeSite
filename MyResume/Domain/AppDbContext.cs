using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyResume.Domain.Entities;

namespace MyResume.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<TextField> TextFields { get; set; }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("bce2618a-249b-468c-8138-fb6ae8522b4c"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });


            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("be0a8594-a075-406b-8d23-99f58d4f6c1f"),
                CodeWord = "PageSkills",
                Title = "Мои умения"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("afd5f3cc-e49d-4ca5-bfb2-3c78141d243e"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
        }
    }
}
