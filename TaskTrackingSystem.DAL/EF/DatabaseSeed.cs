using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.DAL.EF
{
    public static class DatabaseSeed
    {
        public static void SeedDatabase(this ModelBuilder builder)
        {
            var rolesList = new List<IdentityRole>
            {
                new IdentityRole{Name = "User",NormalizedName = "USER"},
                new IdentityRole{Name = "Manager",NormalizedName = "MANAGER"},
                new IdentityRole{Name = "Admin",NormalizedName = "ADMIN"},
            };

            builder.Entity<IdentityRole>().HasData(rolesList);

            var hasher = new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "admin")
            };
            
            builder.Entity<ApplicationUser>().HasData(user);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = rolesList[2].Id,
                    UserId = user.Id
                }
            );
        }
    }
}