using BountyHunters.Common;
using BountyHunters.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BountyHunters.Data.Configurations
{
    public class CriminalConfiguration : IEntityTypeConfiguration<Criminal>
    {
        public void Configure(EntityTypeBuilder<Criminal> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(ApplicationConstants.CriminalNameMaxLength);

            builder.Property(e => e.CrimeType)
                .IsRequired()
                .HasMaxLength(ApplicationConstants.CriminalCrimeTypeMaxLength);

            builder.Property(e => e.Bounty)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(e => e.Status)
                .IsRequired();


            builder.HasData(this.SeedCriminals());

        }

        private IEnumerable<Criminal> SeedCriminals()
        {
            IEnumerable<Criminal> criminals = new List<Criminal>()
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

    }
}



