using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectPlanner.Models;
using ProjectPlanner.Utilities;

namespace ProjectPlanner.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Project>().HasData(
            //    new Project { Id = 1, Name = "Mahatan Project", Description = "Create biggest bomb ever" },
            //    new Project { Id = 2, Name = "Apollo Project", Description = "Put man on the moon" }
            //);

            //modelBuilder.Entity<Ticket>().HasData(
            //    new Ticket { Id=1 , Title= "Split Atom", CreatedOn = DateTime.Now, Description = "Succesfully split a atom", Priority = SD.priority_medium, ProjectId = 1, Status = SD.status_new},
            //    new Ticket { Id=2 , Title= "Find Plutonium", CreatedOn = DateTime.Now, Description = "Find plutunium for the bomb", Priority = SD.priority_high, ProjectId = 1, Status = SD.status_new},
            //    new Ticket { Id=3 , Title= "Find Astronaut", CreatedOn = DateTime.Now, Description = "Find someone willingly to go to the moon", Priority = SD.priority_low, ProjectId = 2, Status = SD.status_new},

            //    new Ticket { Id=4 , Title= "Create w16 engine", CreatedOn = DateTime.Now, Description = "Create engine with w16 orientation", Priority = SD.priority_medium, ProjectId = 4, Status = SD.status_new}
            //);

        }

    }
}
