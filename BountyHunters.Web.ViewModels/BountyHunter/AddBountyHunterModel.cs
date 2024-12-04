

using BountyHunters.Common;
using System.ComponentModel.DataAnnotations;

namespace BountyHunters.Web.ViewModels.BountyHunter
{
    public class AddBountyHunterModel
    {
        [Required(ErrorMessage = "Name input is required")]
        [MaxLength(ApplicationConstants.BountyHunterNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ApplicationConstants.BountyHunterRankMaxLength)]
        public string Rank { get; set; } = null!;

        [MaxLength(ApplicationConstants.BountyHunterBioMaxLength)]
        public string Bio { get; set; } = null!;
    }
}
