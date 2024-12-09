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
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(ApplicationConstants.BountyHunterNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ApplicationConstants.BountyHunterRankMaxLength)]
        public string Rank { get; set; } = null!;

        [MaxLength(ApplicationConstants.BountyHunterBioMaxLength)]
        public string Bio { get; set; } = null!;

        public virtual ICollection<Capture> Captures { get; set; } = new HashSet<Capture>();
        public virtual ICollection<Achievement> Achievements { get; set; } = new HashSet<Achievement>();
        public int CaptureCount { get; set; } = 0;
    }
}
