
using BountyHunters.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BountyHunters.Data.Configurations
{
    public class BountyHunterConfiguration : IEntityTypeConfiguration<BountyHunter>
    {
        public void Configure(EntityTypeBuilder<BountyHunter> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Rank)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.Bio)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.CaptureCount)
                .IsRequired()
                .HasDefaultValue(0);


            builder.HasMany(b => b.Captures)
                .WithOne(c => c.BountyHunter)
                .HasForeignKey(c => c.BountyHunterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.SeedBountyHunters());
        }

        private IEnumerable<BountyHunter> SeedBountyHunters()
        {
            IEnumerable<BountyHunter> bountyHunters = new List<BountyHunter>()
            {
                new BountyHunter
                {
                    Id = Guid.NewGuid(), 
                    Name = "John Tracker",
                    Rank = "Novice",
                    Bio = "A new bounty hunter ready for action.",
                    CaptureCount = 0 
                },
                new BountyHunter
                {
                    Id = Guid.NewGuid(),
                    Name = "Jane Swift",
                    Rank = "Expert",
                    Bio = "Experienced bounty hunter with countless captures.",
                    CaptureCount = 8
                },
                new BountyHunter
                {
                    Id = Guid.NewGuid(),
                    Name = "Alice Tracker",
                    Rank = "Novice",
                    Bio = "New bounty hunter",
                    CaptureCount = 0
                },
                new BountyHunter
                {
                    Id = Guid.NewGuid(),
                    Name = "Bob Hunter",
                    Rank = "Expert",
                    Bio = "Seasoned hunter.",
                    CaptureCount = 10
                }
            };
            return bountyHunters;
        }
    }
}
