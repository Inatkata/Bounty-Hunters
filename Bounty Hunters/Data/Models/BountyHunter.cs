using System.Text.RegularExpressions;

namespace Bounty_Hunters.Data.Models
{
    public class BountyHunter
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Name of the hunter
        public string Rank { get; set; } = "Novice"; // Hunter rank (default: Novice)
        public int CaptureCount { get; set; } = 0; // Number of captures
        public string ProfileImage { get; set; } // URL to profile image
        public string Bio { get; set; } // Short biography

        // Navigation property
        public ICollection<Capture> Captures { get; set; } = new List<Capture>();
        public ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
    }

}
