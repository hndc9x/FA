using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class QuizHTML
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Ten { get; set; }
        [MaxLength(200)]
        public string DapAn1 { get; set; }
        public string DapAn2 { get; set; }
        public string DapAn3 { get; set; }
        public string DapAn4 { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
