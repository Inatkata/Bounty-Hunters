using BountyHunters.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BountyHunters.Data.Models
{
    public class BountyHunter
    {
        public BountyHunter()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ApplicationConstants.BountyHunterNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ApplicationConstants.BountyHunterRankMaxLength)]
        public string Rank { get; set; } = "Novice";

        [MaxLength(ApplicationConstants.BountyHunterBioMaxLength)]
        public string Bio { get; set; } = null!;

        public ICollection<Capture> Captures { get; set; } = new List<Capture>();
        public ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
        public int CaptureCount { get; set; }
    }
}
