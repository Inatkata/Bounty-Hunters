using BountyHunters.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BountyHunters.Data.Configurations
{
    public class CaptureConfiguration : IEntityTypeConfiguration<Capture>
    {
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
    }  


}
