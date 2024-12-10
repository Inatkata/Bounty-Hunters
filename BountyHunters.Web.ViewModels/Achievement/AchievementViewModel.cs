namespace BountyHunters.Web.ViewModels.Achievement
{
    using System.ComponentModel.DataAnnotations;

    public class AchievementViewModel
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(300)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Date is required.")]
        public DateTime DateAchieved { get; set; }

        public string BountyHunterId { get; set; } = null!;

        // The name of the bounty hunter for display purposes
        public string BountyHunterName { get; set; } = null!;
    }
}