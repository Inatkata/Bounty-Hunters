using BountyHunters.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BountyHunters.Web.ViewModels.Achievement
{
    public class AddAchievementInputModel
    {

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

    }
}
