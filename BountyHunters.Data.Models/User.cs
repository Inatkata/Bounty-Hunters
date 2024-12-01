using BountyHunters.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BountyHunters.Data.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ApplicationConstants.UserNameMaxLength)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(ApplicationConstants.UserEmailMaxLength)]
        public string Email { get; set; } = null!;
    }
}
