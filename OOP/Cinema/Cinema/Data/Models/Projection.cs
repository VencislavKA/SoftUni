using AutoMapper.QueryableExtensions;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;

namespace Cinema.Data.Models
{
    public class Projection
    {
        public Projection()
        {
            Tickets = new HashSet<Ticket>();
        }
        //Id – integer, Primary Key
        //MovieId – integer, foreign key(required)
        //Movie – the projection’s movie
        //HallId – integer, foreign key(required)
        //Hall – the projection’s hall
        //DateTime - DateTime(required)
        //Tickets - collection of type Ticket
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Required]
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
