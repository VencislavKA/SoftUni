using AutoMapper.QueryableExtensions;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Cache;

namespace Cinema.Data.Models
{
    public class Seat
    {
        //        Id – integer, Primary Key
        //HallId – integer, foreign key(required)
        //Hall – the seat’s hall   
        [Key]
        public int Id { get; set; }
        [Required,ForeignKey("Hall")]
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
