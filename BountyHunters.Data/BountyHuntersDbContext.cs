using System.Reflection;
using BountyHunters.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BountyHunters.Data
{
    public class BountyHuntersDbContext : DbContext
    {
        public BountyHuntersDbContext()
        {
             
        }
        public BountyHuntersDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Criminal> Criminals { get; set; }
        public DbSet<BountyHunter> BountyHunters { get; set; }
        public DbSet<Capture> Captures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
