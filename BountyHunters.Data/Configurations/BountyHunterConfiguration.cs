using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BountyHunters.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BountyHunters.Data.Configurations
{
    public class BountyHunterConfiguration : IEntityTypeConfiguration<BountyHunter>
    {
        public void Configure(EntityTypeBuilder<BountyHunter> builder)
        {
            builder.HasMany(b => b.Captures)
                .WithOne(c => c.BountyHunter)
                .HasForeignKey(c => c.BountyHunterId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
