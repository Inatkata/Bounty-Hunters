
using BountyHunters.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BountyHunters.Web.ViewModels.Criminal
{
    public class AddCriminalInputModel
    {
        [Required]
        [MaxLength(ApplicationConstants.CriminalNameMaxLength)]
        [MinLength(ApplicationConstants.CriminalNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ApplicationConstants.CriminalCrimeTypeMaxLength)]
        [MinLength(ApplicationConstants.CriminalCrimeTypeMinLength)]
        public string CrimeType { get; set; } = null!;

        [Range(0, double.MaxValue)]
        public decimal Bounty { get; set; }

        [Required]
        public string Status { get; set; } = "At Large";

        public DateTime? CaptureDate { get; set; }
    }
}
