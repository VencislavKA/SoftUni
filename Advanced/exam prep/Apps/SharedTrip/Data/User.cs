using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedTrip.Data
{
    public class User
    {
        public User()
        {
            this.UserTrips = new HashSet<UserTrip>();
        }
        
        [Key]
        public string Id { get; set; }


        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [MinLength(6)]
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }

        public HashSet<UserTrip> UserTrips { get; set; }
    }
}
