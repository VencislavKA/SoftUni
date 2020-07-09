using System;
using System.Collections.Generic;

namespace scaffloadtest.Models
{
    public partial class Passports
    {
        public int PassportId { get; set; }
        public string PassportNumber { get; set; }

        public virtual Persons Persons { get; set; }
    }
}
