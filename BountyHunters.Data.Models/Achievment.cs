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
        public Achievement()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ApplicationConstants.AchievementNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ApplicationConstants.AchievementDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public DateTime DateAchieved { get; set; }

        public int BountyHunterId { get; set; }
        public BountyHunter BountyHunter { get; set; } = null!;
    }
}
