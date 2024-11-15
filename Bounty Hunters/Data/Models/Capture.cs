using Bounty_Hunters.Data.Models.Models;

namespace Bounty_Hunters.Data.Models
{
    public class Capture
    {
        public int Id { get; set; } // Primary Key
        public int BountyHunterId { get; set; } // Foreign Key to BountyHunter
        public int CriminalId { get; set; } // Foreign Key to Criminal
        public DateTime CaptureDate { get; set; } // Date of capture
        public string Notes { get; set; } // Additional notes about the capture

        // Navigation properties
        public BountyHunter BountyHunter { get; set; }
        public Criminal Criminal { get; set; }
    }

}
