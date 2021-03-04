using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class RecordQuestion
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("QuestionPaper")]
        public int QuestionPaperId { get; set; }
        public virtual QuestionPaper QuestionPaper { get; set; }
        public int RecordId { get; set; }
        public virtual Record Record { get; set; }
        public double Point { get; set; }
        public bool IsPassed { get; set; }
    }
}
