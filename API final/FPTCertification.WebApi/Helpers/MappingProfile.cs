using AutoMapper;
using FPTCertification.Business.Models;
using FPTCertification.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPTCertification.WebApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Skill, ResponseSelectSkill>();
            CreateMap<Certification, RequestCreateCertification>().ForMember(model => model.Skills, c => c.MapFrom(c => c.CertificationSkills.Select(cs => cs.Skill)));
        }
            
    }
    //// Source
    //public class User
    //{
    //    public int Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Email { get; set; }
    //    public string Address { get; set; }
    //}
    //// Destination
    //public class UserViewModel
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Email { get; set; }
    //}

}
