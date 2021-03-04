using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        // Neu la cha thi null
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Activated { get; set; }
        public string UrlSlug { get; set; }
        public virtual ICollection<Certification> Certifications { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
    }
}
