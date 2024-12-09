using BountyHunters.Common;

using System.ComponentModel.DataAnnotations;


namespace BountyHunters.Data.Models
{
    public class Capture
    {
        
       
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public Guid BountyHunterId { get; set; }
        [Required]
        public Guid CriminalId { get; set; }

        public DateTime CaptureDate { get; set; }

        [MaxLength(ApplicationConstants.CaptureNotesMaxLength)]
        public string Notes { get; set; } = null!;

        public BountyHunter BountyHunter { get; set; } = null!;
        public Criminal Criminal { get; set; } = null!;
    }
}
