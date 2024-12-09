using BountyHunters.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BountyHunters.Data.Models
{
    public class Achievement
    {
       
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(300)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Date is required.")]
        public DateTime DateAchieved { get; set; }

        public string BountyHunterId { get; set; } = null!;

        public string BountyHunterName { get; set; } = null!;
    }
}
