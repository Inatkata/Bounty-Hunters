using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using BountyHunters.Common;


namespace BountyHunters.Data.Models
{
    public class Criminal
    {
        public Criminal()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

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
        public virtual ICollection<Capture> Captures { get; set; } = new HashSet<Capture>();
    }
}
