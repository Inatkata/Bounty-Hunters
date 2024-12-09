using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BountyHunters.Web.ViewModels.Criminal
{
    public class CriminalInputModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string CrimeType { get; set; } = null!;
        public decimal Bounty { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? CaptureDate { get; set; }
    }
}
