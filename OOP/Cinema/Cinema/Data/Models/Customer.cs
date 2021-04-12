using AutoMapper.QueryableExtensions;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Cache;

namespace Cinema.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            Tickets = new List<Ticket>();
        }
        //Id – integer, Primary Key
        //FirstName – text with length[3, 20] (required)
        //LastName – text with length[3, 20] (required)
        //Age – integer in the range[12, 110] (required)
        //Balance - decimal (non-negative, minimum value: 0.01) (required)
        //Tickets - collection of type Ticket
        [Key]
        public int Id { get; set; }

        [MinLength(3)][MaxLength(20)][Required]
        public string FirstName { get; set; }

        [MinLength(3)][MaxLength(20)][ Required]
        public string LastName { get; set; }

        [Range(12,110),Required]
        public int Age { get; set; }

        [Required][Range(0.01, (double)decimal.MaxValue)]
        public decimal Balance { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
