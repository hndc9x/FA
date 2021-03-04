using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Member")]
        public string MemberId { get; set; }
        public virtual Member Member { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public DateTime EnrollDate { get; set; }    
        public DateTime ExpiredDate { get; set; }
        // using for enable ExpiredDate
        public bool ExpiredDateEnable { get; set; }
        public int TotalTakeCount { get; set; }
        public bool Activated { get; set; }
        public virtual ICollection<EnrollPaper> EnrollPapers  { get; set; }

    }
}
