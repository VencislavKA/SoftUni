using System;
using System.Collections.Generic;

namespace scaffloadtest.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public int? CityId { get; set; }

        public virtual Cities City { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
