using BountyHunters.Common;
using BountyHunters.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BountyHunters.Data.Configurations
{
    public class AchievementConfiguration : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(ApplicationConstants.AchievementNameMaxLength);

            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(ApplicationConstants.AchievementDescriptionMaxLength);

            builder.Property(a => a.DateAchieved)
                .IsRequired();

            builder.Property(a => a.BountyHunterId)
                .IsRequired();

            builder.HasOne(a => a.BountyHunter)
                .WithMany(b => b.Achievements)
                .HasForeignKey(a => a.BountyHunterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(this.SeedAchievements());
        }

        private IEnumerable<Achievement> SeedAchievements()
        {
            return new List<Achievement>
            {
                new Achievement
                {
                    Id = Guid.NewGuid(),
                    Name = "First Capture",
                    Description = "Successfully captured the first criminal.",
                    DateAchieved = DateTime.UtcNow.AddDays(-30),
                    BountyHunterId = Guid.Parse("763BB5A4-65CA-445F-ADEE-846098CA0B57") // Example hunter ID
                },
                new Achievement
                {
                    Id = Guid.NewGuid(),
                    Name = "Top Hunter",
                    Description = "Achieved the highest number of captures in a month.",
                    DateAchieved = DateTime.UtcNow.AddDays(-15),
                    BountyHunterId = Guid.Parse("FE4401E8-927D-4ED4-92EE-414B00904977") // Example hunter ID
                }
            };
        }
    }
}
