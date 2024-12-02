using BountyHunters.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
