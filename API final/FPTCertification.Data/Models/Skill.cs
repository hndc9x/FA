using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Activated { get; set; }
        public string UrlSlug { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual IList<CertificationSkill> CertificationSkills { get; set; }
    }   
}
