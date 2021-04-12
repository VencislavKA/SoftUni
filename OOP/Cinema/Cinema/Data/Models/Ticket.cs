using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Data.Models
{
    public class Ticket
    {
        //        Id – integer, Primary Key
        //Price – decimal (non-negative, minimum value: 0.01) (required)
        //CustomerId – integer, foreign key(required)
        //Customer – the customer’s ticket
        //ProjectionId – integer, foreign key(required)
        //Projection – the projection’s ticket
        public int Id { get; set; }

        [Range(0.01, (double)decimal.MaxValue), Required]
        public decimal Price { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required, ForeignKey("Projection")]
        public int ProjectionId { get; set; }
        public Projection Projection { get; set; }
    }
}
