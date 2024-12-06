

using System.ComponentModel.DataAnnotations;
using BountyHunters.Common;


namespace BountyHunters.Web.ViewModels.Criminal
{

    public class AddCriminalInputModel
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "Name input is required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Crime type is required")]
        public string CrimeType { get; set; } = null!;

        [Range(0, double.MaxValue)]
        public decimal Bounty { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = null!;

        public DateTime? CaptureDate { get; set; }
    }

}
