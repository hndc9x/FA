using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;

namespace FPTCertification.Data.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual AppUser AppUser { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Activated { get; set; }
        [ForeignKey("Classes")]
        public int ClassId { get; set; }
        public virtual Classes Classes { get; set; }
    }
}
