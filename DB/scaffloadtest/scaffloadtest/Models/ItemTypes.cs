using System;
using System.Collections.Generic;

namespace scaffloadtest.Models
{
    public partial class ItemTypes
    {
        public ItemTypes()
        {
            Items = new HashSet<Items>();
        }

        public int ItemTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
