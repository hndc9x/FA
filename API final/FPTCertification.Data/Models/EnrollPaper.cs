using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class EnrollPaper
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Enrollment")]
        public int EnrollmentId { get; set; }
        public virtual Enrollment Enrollment { get; set; }
        public int TestPaperId { get; set; }
        public virtual TestPaper TestPaper { get; set; }
        public int TakeCount { get; set; }
        public bool Activated { get; set; }
        public virtual ICollection<Record> Records { get; set; }

    }
}
