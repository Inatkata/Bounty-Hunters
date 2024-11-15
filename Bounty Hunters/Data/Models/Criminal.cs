using System.Text.RegularExpressions;

namespace Bounty_Hunters.Data.Models

{
    public class Criminal
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Name of the criminal
        public string CrimeType { get; set; } // Type of crime (e.g., theft, fraud)
        public decimal Bounty { get; set; } // Reward for capturing
        public string Status { get; set; } = "At Large"; // Status (default: At Large)
        public DateTime? CaptureDate { get; set; } // Date of capture (nullable)
        public string Description { get; set; } // Detailed description of crimes

        // Navigation property
        public ICollection<Capture> Captures { get; set; } = new List<Capture>();
    }

}
