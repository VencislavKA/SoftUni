using AutoMapper.QueryableExtensions;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Cache;

namespace Cinema.Data.Models
{
    public class Hall
    {
        public Hall()
        {
            this.Projections = new HashSet<Projection>();
            this.Seats = new HashSet<Seat>();
        }
        //Projections - collection of type Projection
        //Seats - collection of type Seat
        [Key]
        public int Id { get; set; }
        [MinLength(3)][MaxLength(20)]
        [Required]
        public string Name { get; set; }
        public bool Is4Dx { get; set; }
        public bool Is3D { get; set; }
        public ICollection<Projection> Projections { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
