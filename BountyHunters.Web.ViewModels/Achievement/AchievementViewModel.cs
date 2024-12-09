using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BountyHunters.Web.ViewModels.Achievement
{
    using System.ComponentModel.DataAnnotations;

    namespace BountyHunters.Web.ViewModels.Achievement
    {
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

            public string BountyHunterName { get; set; } = null!;
        }
    }

}
