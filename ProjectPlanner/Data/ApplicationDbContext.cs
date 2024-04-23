using Microsoft.EntityFrameworkCore;
using ProjectPlanner.Models;

namespace ProjectPlanner.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "Mahatan Project", Description = "Create biggest bomb ever" },
                new Project { Id = 2, Name = "Apollo Project", Description = "Put man on the moon" }
            );

        }

    }
}
