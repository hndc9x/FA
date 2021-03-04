using FPTCertification.Business.Models;
using FPTCertification.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Services
{
    public class SkillServices : BaseService<Skill, int>
    {
        public SkillServices(DataContext context) : base(context)
        {
        }

        public void PrepareCreate(Skill entity)
        {
            entity.Activated = true;
            entity.CreateDate = DateTime.Now;
            entity.ModifyDate = DateTime.Now;
        }

        public void PrepareUpdate(Skill entity)
        {
            entity.ModifyDate = DateTime.Now;
        }

        // Get All Skills
        public IEnumerable<Skill> GetAllSkills()
        {
            return GetAll();
        }

        // Get Skill By Id
        public Skill GetSkillById(int id)
        {
            return GetById(id);
        }

        // Create new Skill
        public Skill CreateSkill(RequestCreateSkill model)
        {
            var entity = model.ToEntity();
            PrepareCreate(entity);    
            return Add(entity);
        }

        // Update A Skill
        public Skill UpdateSkill(Skill entity)
        {
            PrepareUpdate(entity);
            return Update(entity);
        }

        // Delete a Skill
        public Skill DeleteSkill(Skill entity)
        {
            return Delete(entity);
        }

        // Get Skills By Name Search
        public IList<Skill> GetSkillsByName(string name)
        {
            IList<Skill> list = new List<Skill>();
            foreach (var item in GetAllSkills())
            {
                if (item.Name.Contains(name.ToLower()))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        // Update Status
        public Skill ChangeStatus(RequestUpdateStatusSkill model)
        {
            var entity = GetSkillById(model.Id);
            if (entity.Activated == true)
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
