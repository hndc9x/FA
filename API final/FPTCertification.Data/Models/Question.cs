using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string Point { get; set; }
        public string Image { get; set; }
        public int? ParentId { get; set; }
        public virtual Question ParentQuestion { get; set; }
        [ForeignKey("Skill")]
        public int? SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Activated { get; set; }
        public string UrlSlug { get; set; }
        public bool RandomAnswer { get; set; }
        public string FeedbackCorrect { get; set; }
        public string FeedbackIncorrect { get; set; }
        [ForeignKey("QuestionType")]
        public string Type { get; set; }
        public virtual QuestionType QuestionType { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Question> ChildQuestion { get; set; }

    }
}
