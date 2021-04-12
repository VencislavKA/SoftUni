using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Data
{
    public class UserTrip
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string TripId { get; set; }//can be id instead of Id
        public Trip Trip { get; set; }
    }
}
