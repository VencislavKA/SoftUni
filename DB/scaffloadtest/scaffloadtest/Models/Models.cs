using System;
using System.Collections.Generic;

namespace scaffloadtest.Models
{
    public partial class Models
    {
        public int ModelId { get; set; }
        public string Name { get; set; }
        public int? ManufacturerId { get; set; }

        public virtual Manufacturers Manufacturer { get; set; }
    }
}
