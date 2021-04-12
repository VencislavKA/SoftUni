using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUsersAndCardsJsonDto
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^([A-Z?][a-z]+)\s([A-Z?][a-z]+)$")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        public ImpordCardsDto[] Cards { get; set; }
    }

    public class ImpordCardsDto
    {
        [Required]
        [RegularExpression(@"^(\d{4})\s(\d{4})\s(\d{4})\s(\d{4})$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^(\d{3})$")]
        public string Cvc { get; set; }

        [Required]
        [Range(0, 1)]
        public CardType Type { get; set; }
    }
}
