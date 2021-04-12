using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace BattleCards.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        [MinLength(5)][MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [MinLength(6)][MaxLength(20)]
        [Required]
        public string Password { get; set; }

        public ICollection<Card> UserCard { get; set; }
    }
}
