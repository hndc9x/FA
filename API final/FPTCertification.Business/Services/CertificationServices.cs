using FPTCertification.Business.Models;
using FPTCertification.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FPTCertification.Business.Services
{
    public class CertificationServices : BaseService<Certification, int>
    {
        private readonly DataContext _ctx;
        private readonly SkillServices _skillservices;

        public CertificationServices(DataContext context) : base(context)
        {
            _ctx = context;
            _skillservices = new SkillServices(context);
        }

        // Automatic Add CreateDate & ModifyDate & Activated = true before create new class
        public void PrepareCreate(Certification certification)
        {
            certification.CreateDate = DateTime.Now;
            certification.ModifyDate = DateTime.Now;
            certification.Activated = true;
        }

        // Automatic Update modify date before update a class
        public void PrepareUpdate(Certification certification)
        {
            certification.ModifyDate = DateTime.Now;
        }

        // Get All Certifications
        public IEnumerable<Certification> GetAllCertifications()
        {
            return GetAll();
        }

        // Create Certification
        public Certification CreateCertification(RequestCreateCertification model)
        {
            var entity = model.ToEntity();
            IList<ResponseSelectSkill> listSkill = model.Skills;
            PrepareCreate(entity);
            Certification _certification = Add(entity);    
            Commit();
            ICollection<CertificationSkill> list = new List<CertificationSkill>();
            CertificationSkill cs;
            foreach (var item in listSkill)
            {
                Skill _skill = _skillservices.GetSkillById(item.Id);
                cs = new CertificationSkill { Certification = _certification, Skill = _skill };
                _ctx.Add(cs);
                Commit();
                list.Add(cs);
            }
            
            _certification.CertificationSkills = list;
            return _certification;
        }

        // Update Certification
        public Certification UpdateCertification(RequestUpdateCertification model)
        {
            var entity = model.ToEntity();
            PrepareUpdate(entity);
            Certification _certification = Update(entity);
            foreach (var item in _ctx.CertificationSkills)
            {
                if(item.CertificationId == model.Id)
                {
                    _ctx.CertificationSkills.Remove(item);
                }
            }
            foreach (var item in model.Skills)
            {
                _ctx.CertificationSkills.Add(new CertificationSkill() { CertificationId = model.Id, SkillId = item.Id });
            }
            Commit();
            return _certification;
        }

        // Get Certification By Id
        public Certification GetCertificationById(int id)
        {
            return GetById(id);
        }

        // Get Skill By CertificationId in CertificationSkills
        public IList<Skill> GetSkillByCertificationId(int id)
        {
            IList<Skill> listSkill = new List<Skill>();
            foreach (var item in _ctx.CertificationSkills)
            {
                if(item.CertificationId == id)
                {
                    Skill _skill = _skillservices.GetSkillById(item.SkillId);
                    listSkill.Add(_skill);
                } 
            }
            return listSkill;
        }

        // Delete a Certification
        public Certification DeleteCertification(Certification entity)
        {
            return Delete(entity);
        }

        // Update Status
        public Certification ChangeStatus(RequestUpdateStatusCertification model)
        {
            var entity = GetCertificationById(model.Id);
            if(entity.Activated == true)
            {
                entity.Activated = false;
            }
            else
            {
                entity.Activated = true;
            }
            return entity;
        }
    }
}
