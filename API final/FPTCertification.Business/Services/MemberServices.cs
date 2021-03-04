using FPTCertification.Business.Models;
using FPTCertification.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPTCertification.Business.Services
{
    public class MemberServices : BaseService<Member, string>
    {

        private readonly ClassServices classServices;

        public MemberServices(DataContext context) : base(context)
        {
            classServices = new ClassServices(context);
        }
        public void PrepareCreate(Member entity)
        {

        }

        public void PrepareUpdate(Member entity)
        {

        }
        // Get all Members
        public IEnumerable<Member> GetAllMembers()
        {
            return GetAll();
        }
        public Member GetMemberById(string id)
        {

            return GetById(id);
        }
        public Member GetMemById(string id)
        {
            return GetById(id);
        }
        public Member CreateMember(RequestCreateMember model)
        {
            var entity = model.ToEntity();
            PrepareCreate(entity);
            return Add(entity);
        }
        public Member UpdateMember(Member entity)
        {
            PrepareUpdate(entity);
            return Update(entity);
        }

        public Member DeleteMember(Member entity)
        {
            return Delete(entity);
        }
        // Get Member By Classes
        public IList<Member> GetMemberByClassId(int id)
        {
            List<Member> list = new List<Member>();
            Classes _class = classServices.GetClassById(id);
            foreach (var item in GetAllMembers())
            {
                if (item.ClassId.Equals(_class.Id))
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
