using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class QuestionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Activated { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
