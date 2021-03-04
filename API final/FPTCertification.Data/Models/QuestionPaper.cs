using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class QuestionPaper
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TestPaper")]
        public int TestPaperId { get; set; }
        public TestPaper TestPaper { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public double Point { get; set; }
    }
}
