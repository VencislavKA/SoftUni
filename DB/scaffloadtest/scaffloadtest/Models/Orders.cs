using System;
using System.Collections.Generic;

namespace scaffloadtest.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
