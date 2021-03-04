using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Activated { get; set; }
        public string UrlSlug { get; set; }
        public bool TrueAnswer { get; set; }
        public int Position { get; set; }
    }
}
