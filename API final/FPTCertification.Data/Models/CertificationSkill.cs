using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FPTCertification.Data.Models
{
    // the hien trong database dung de query
    // ko can tao model
    public class CertificationSkill
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        [ForeignKey("Certification")]
        public int CertificationId { get; set; }
        public virtual Certification Certification { get; set; }
    }
}
