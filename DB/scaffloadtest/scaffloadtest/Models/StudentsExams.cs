using System;
using System.Collections.Generic;

namespace scaffloadtest.Models
{
    public partial class StudentsExams
    {
        public int StudentId { get; set; }
        public int Exam { get; set; }

        public virtual Exams ExamNavigation { get; set; }
        public virtual Students Student { get; set; }
    }
}
