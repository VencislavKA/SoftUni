using AutoMapper.QueryableExtensions;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Cinema.Data.Models.Enums;

namespace Cinema.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            Projections = new HashSet<Projection>();
            Genre = new Genre();
        }
        [Key]
        
        public int Id { get; set; }

        [MinLength(3)][MaxLength(20)]
        [Required]
        public string Title { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Range(1,10)]
        [Required]
        public double Rating { get; set; }
        [MinLength(3)][MaxLength(20)]
        [Required]
        public string Director { get; set; }
        public ICollection<Projection> Projections { get; set; }
    }
}
