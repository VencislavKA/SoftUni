using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace BattleCards.Models
{
    public class UserCard
    {
        //        •	Has UserId – a string
        //•	Has User – a User object
        //•	Has CardId – an int
        //•	Has Card – a Card object
        public string UserId { get; set; }
        public User User { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
