using System;
using System.Collections.Generic;

namespace scaffloadtest.Models
{
    public partial class Persons
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public float? Salary { get; set; }
        public int PassportId { get; set; }

        public virtual Passports Passport { get; set; }
    }
}
