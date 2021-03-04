using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class TestPaper
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int Title { get; set; }
        public string TestType  { get; set; }
        public bool FeedbackTest  { get; set; }
        public string QuestionTypeCode { get; set; }
        // timming
        public DateTime OpenTime { get; set; }
        public bool OpenTimeEnable { get; set; }
        public DateTime CloseTime { get; set; }
        public bool CloseTimeEnable { get; set; }
        public TimeSpan Duration { get; set; }
        public bool DurationEnable { get; set; }
        // grade
        public double TotalGrace { get; set; }
        public double GradeToPass { get; set; }
        public int Attempts { get; set; }
        // layout
        public int QuestionInPage { get; set; }
        // enable random position of question
        public bool SufferQuestion { get; set; }
        public string ImageUrl { get; set; }
        // base
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Activated { get; set; }
        public string UrlSlug { get; set; }
        public bool DisplayPoint { get; set; }
        public virtual ICollection<EnrollPaper> EnrollPapers { get; set; }
        public virtual ICollection<QuestionPaper> QuestionPapers { get; set; }
    }
}
