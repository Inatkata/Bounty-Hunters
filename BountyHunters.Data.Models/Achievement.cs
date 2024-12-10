using System.ComponentModel.DataAnnotations;
using BountyHunters.Common;

namespace BountyHunters.Data.Models
{
    public class Achievement
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(ApplicationConstants.AchievementNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(ApplicationConstants.AchievementDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Date is required.")]
        public DateTime DateAchieved { get; set; }

        [Required]
        public Guid BountyHunterId { get; set; }

        // Navigation property for the related BountyHunter
        public BountyHunter BountyHunter { get; set; } = null!;
    }
}