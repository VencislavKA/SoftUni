using System;
using System.Collections.Generic;

namespace scaffloadtest.Models
{
    public partial class Manufacturers
    {
        public Manufacturers()
        {
            Models = new HashSet<Models>();
        }

        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public DateTime EstablishedOn { get; set; }

        public virtual ICollection<Models> Models { get; set; }
    }
}
