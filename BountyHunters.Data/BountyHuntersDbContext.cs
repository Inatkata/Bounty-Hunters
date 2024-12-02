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

        public virtual DbSet<Criminal> Criminals { get; set; } = null!;
        public virtual DbSet<BountyHunter> BountyHunters { get; set; } = null!;
        public virtual DbSet<Capture> Captures { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
