using BountyHunters.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BountyHunters.Data.Models
{
    public class Achievement
    {
       
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(ApplicationConstants.AchievementNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ApplicationConstants.AchievementDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public DateTime DateAchieved { get; set; }

        public Guid BountyHunterId { get; set; }
        public BountyHunter BountyHunter { get; set; } = null!;
    }
}
