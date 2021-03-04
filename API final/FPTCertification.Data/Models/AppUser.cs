using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class AppUser : IdentityUser<string>
    {
        public string Fullname { get; set; }
    }
}
