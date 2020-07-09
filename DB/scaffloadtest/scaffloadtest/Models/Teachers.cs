using System;
using System.Collections.Generic;

namespace scaffloadtest.Models
{
    public partial class Teachers
    {
        public Teachers()
        {
            InverseManager = new HashSet<Teachers>();
        }

        public int TeacherId { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }

        public virtual Teachers Manager { get; set; }
        public virtual ICollection<Teachers> InverseManager { get; set; }
    }
}
