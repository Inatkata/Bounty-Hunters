using BountyHunters.Common;
using BountyHunters.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BountyHunters.Data.Configurations
{
    public class BountyHunterConfiguration : IEntityTypeConfiguration<Criminal>
    {
        public void Configure(EntityTypeBuilder<Criminal> builder)
        {
            builder.HasKey(c => c.Id);
            builder
                .Property(c => c.Bounty)
                .IsRequired()
                .HasPrecision(18, 2);
            builder
                .Property(c => c.CrimeType)
                .IsRequired()
                .HasMaxLength(ApplicationConstants.CriminalCrimeTypeMaxLength);


            builder.HasData(this.SeedCriminals());

        }

        public void Configure(EntityTypeBuilder<Capture> builder)
        {
            builder
                .HasOne(c => c.BountyHunter)
                .WithMany(b => b.Captures)
                .HasForeignKey(c => c.BountyHunterId);
            builder
                .HasOne(c => c.Criminal)
                .WithMany(c => c.Captures)
                .HasForeignKey(c => c.CriminalId);
        }

        private List<Criminal> SeedCriminals()
        {
            List<Criminal> criminals = new List<Criminal>()
            {
                new Criminal
                {
                    Name = "Eve Rogue",
                    CrimeType = "Hacking",
                    Bounty = 10000,
                    Status = "At Large"
                },
                new Criminal
                {
                    Name = "John Doe",
                    CrimeType = "Bank Robbery",
                    Bounty = 5000,
                    Status = "At Large"
                },
                new Criminal
                {
                    Name = "Jane Smith",
                    CrimeType = "Fraud",
                    Bounty = 3000,
                    Status = "At Large"
                }

            };
            return criminals;
        }

        private List<Achievement> seedAchievements()
        {
            List<Achievement> achievements = new List<Achievement>()
            {
                new Achievement
                {
                    Name = "First Capture",
                    Description = "Captured your first criminal!",
                    DateAchieved = DateTime.UtcNow
                },
                new Achievement
                {
                    Name = "Top Hunter",
                    Description = "Achieved the highest capture count in a month!",
                    DateAchieved = DateTime.UtcNow.AddDays(-10)
                }
            };
            return achievements;
        }

        private List<BountyHunter> seedBountyHunters()
        {
            List<BountyHunter> bountyHunters = new List<BountyHunter>()
            {
                new BountyHunter
                {
                    Name = "John Hunter",
                    Rank = "Novice",
                    Bio = "An up-and-coming hunter."
                },
                new BountyHunter
                {
                    Name = "Jane Tracker",
                    Rank = "Expert",
                    Bio = "A seasoned expert with numerous captures."
                },
                new BountyHunter
                {
                Name = "Bob Hunter",
                Rank = "Expert",
                Bio = "Seasoned hunter."
                 },
                new BountyHunter
                {
                    Name = "Alice Tracker",
                    Rank = "Novice",
                    Bio = "New bounty hunter."
                }
                };
            return bountyHunters;
        }
    };

}

