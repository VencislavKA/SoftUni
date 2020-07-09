using System;
using System.Collections.Generic;

namespace Exercise.Models
{
    public partial class Diagnose
    {
        public int DiagnoseId { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public int? Patient { get; set; }

        public virtual Patient PatientNavigation { get; set; }
    }
}
