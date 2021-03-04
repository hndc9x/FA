using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class Record
    {
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; }
        [ForeignKey("EnrollPaper")]
        public int EnrollPaperId { get; set; }
        public virtual EnrollPaper EnrollPaper { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public double TotalGrade { get; set; }
        public bool IsPassed { get; set; }
        public virtual ICollection<RecordQuestion> RecordQuestions { get; set; }

    }
}
