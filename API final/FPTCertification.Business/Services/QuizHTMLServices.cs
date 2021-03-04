using FPTCertification.Business.Models;
using FPTCertification.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Services
{
    public class QuizHTMLServices : BaseService<QuizHTML,int>
    {
        public QuizHTMLServices(DataContext context) : base(context)
        {
        }
        public void PrepareCreate(QuizHTML entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.ModifyDate = DateTime.Now;
        }
        public void PrepareUpdate(QuizHTML entity)
        {
            entity.ModifyDate = DateTime.Now;
        }
        // Get ALL Quiz
        public IEnumerable<QuizHTML> GetAllQuizHTML()
        {
            return GetAll();
        }
        public QuizHTML GetQuizHTMLById(int id)
        {
            return GetById(id);
        }

        // Create new Skill
        public QuizHTML CreateQuiz(RequestCreateQuizHTML model)
        {
            var entity = model.ToEntity();
            PrepareCreate(entity);
            return Add(entity);
        }

        // Update A Skill
        public QuizHTML UpdateSkill(QuizHTML entity)
        {
            PrepareUpdate(entity);
            return Update(entity);
        }

        // Delete a Skill
        public QuizHTML DeleteSkill(QuizHTML entity)
        {
            return Delete(entity);
        }
        // Get Skills By Name Search
        public IList<QuizHTML> GetSkillsByName(string name)
        {
            IList<QuizHTML> list = new List<QuizHTML>();
            foreach (var item in GetAllQuizHTML())
            {
                if (item.Ten.Contains(name.ToLower()))
                {
                    list.Add(item);
                }
            }
            return list;
        }

    }
}
