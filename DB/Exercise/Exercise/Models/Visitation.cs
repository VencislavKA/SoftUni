using System;
using System.Collections.Generic;

namespace Exercise.Models
{
    public partial class Visitation
    {
        public int VisitationId { get; set; }
        public DateTime? Date { get; set; }
        public string Comments { get; set; }
        public int? Patient { get; set; }

        public virtual Patient PatientNavigation { get; set; }
    }
}
