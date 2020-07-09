using System;
using System.Collections.Generic;

namespace Exercise.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Diagnose = new HashSet<Diagnose>();
            Visitation = new HashSet<Visitation>();
        }

        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool? HasInsurence { get; set; }

        public virtual ICollection<Diagnose> Diagnose { get; set; }
        public virtual ICollection<Visitation> Visitation { get; set; }
    }
}
