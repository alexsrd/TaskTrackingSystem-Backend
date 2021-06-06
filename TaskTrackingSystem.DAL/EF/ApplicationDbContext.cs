using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.DAL.Entities;

namespace TaskTrackingSystem.DAL.EF
{
    /// <summary>
    /// Database context inherited from IdentityDbContext
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Task>()
                .HasOne(p => p.Project)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.ProjectId);
            
            builder.Entity<Task>()
                .HasOne(p => p.User)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.UserId);

            builder.Entity<Project>()
                .HasMany(p => p.Users)
                .WithMany(u => u.Projects)
                .UsingEntity(j => j.ToTable("UserProject"));

            base.OnModelCreating(builder);
            builder.SeedDatabase();
        }
    }
}