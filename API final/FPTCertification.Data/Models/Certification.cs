using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTCertification.Data.Models
{
    public class Certification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Activated { get; set; }
        public string UrlSlug { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<CertificationSkill> CertificationSkills { get; set; }
    }
}
