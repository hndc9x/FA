using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Activated { get; set; }
        public string UrlSlug { get; set; }
        public virtual ICollection<Member> Members { get; set; }

    }
}
