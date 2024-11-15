using Bounty_Hunters.Data.Models.Models;

namespace Bounty_Hunters.Data.Models
{
    public class Achievement
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Achievement name (e.g., "First Capture")
        public string Description { get; set; } // Description of the achievement
        public DateTime DateAchieved { get; set; } // When it was achieved
        public int BountyHunterId { get; set; } // Foreign Key to BountyHunter

        // Navigation property
        public BountyHunter BountyHunter { get; set; }
    }

}
