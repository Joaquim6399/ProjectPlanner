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

    }
}
