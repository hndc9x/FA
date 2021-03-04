using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class ExamSkill
    {
        [Key]
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int SkillId { get; set; }
        public double Percent { get; set; }
        public bool Activated { get; set; }
    }
}
