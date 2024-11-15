using Bounty_Hunters.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Bounty_Hunters.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Criminal> Criminals { get; set; }
        public DbSet<BountyHunter> BountyHunters { get; set; }
        public DbSet<Capture> Captures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Capture relationships
            modelBuilder.Entity<Capture>()
                .HasOne(c => c.BountyHunter)
                .WithMany(b => b.Captures)
                .HasForeignKey(c => c.BountyHunterId);

            modelBuilder.Entity<Capture>()
                .HasOne(c => c.Criminal)
                .WithMany(c => c.Captures)
                .HasForeignKey(c => c.CriminalId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
