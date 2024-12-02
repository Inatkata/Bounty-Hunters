using System.ComponentModel.DataAnnotations;
using BountyHunters.Common;


namespace BountyHunters.Data.Models
{
    public class Criminal
    {
        public Guid Id { get; set; } = Guid.NewGuid();

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
        public string Status { get; set; } = null!;

        public DateTime? CaptureDate { get; set; }
        public virtual ICollection<Capture> Captures { get; set; } = new HashSet<Capture>();
    }
}
