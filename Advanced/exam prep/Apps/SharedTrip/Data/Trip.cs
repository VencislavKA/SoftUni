﻿using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedTrip.Data
{
    public class Trip
    {
        public Trip()
        {
            this.UserTrips = new HashSet<UserTrip>();
        }

        [Key]
        public string Id { get; set; }

        //        •	Has a StartPoint – a string (required)
        //•	Has a EndPoint – a string (required)
        //•	Has a DepartureTime – a datetime(required) (use format: "dd.MM.yyyy HH:mm")
        //•	Has a Seats – an integer with min value 2 and max value 6 (required)
        //•	Has a Description – a string with max length 80 (required)
        //•	Has a ImagePath – a string
        //•	Has UserTrips collection – a UserTrip type
        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        [Required]
        public DateTime DepartmentTime { get; set; }

        [MinLength(2)]
        [MaxLength(6)]
        [Required]
        public int Seats { get; set; }

        [MaxLength(80)]
        [Required]
        public string Description { get; set; }
        
        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
