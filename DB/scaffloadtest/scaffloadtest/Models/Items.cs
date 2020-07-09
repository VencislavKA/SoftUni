using System;
using System.Collections.Generic;

namespace scaffloadtest.Models
{
    public partial class Items
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int? ItemTypeId { get; set; }

        public virtual ItemTypes ItemType { get; set; }
    }
}
