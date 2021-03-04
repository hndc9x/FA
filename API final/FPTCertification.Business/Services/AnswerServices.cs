using FPTCertification.Business.Models;
using FPTCertification.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Services
{
    public class AnswerServices : BaseService<Answer, int>
    {
        public AnswerServices(DataContext context) : base(context)
        {
        }

        // Automatic Add CreateDate & ModifyDate & Activated before create new Answer
        public void PrepareCreate(Answer entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.ModifyDate = DateTime.Now;
            entity.Activated = true;
        }

        // Automatic update modify date before update an Answer
        public void PrepareUpdate(Answer entity)
        {
            entity.ModifyDate = DateTime.Now;
        }

        // Create Answer
        public Answer CreateAnswer(RequestCreateAnswer model)
        {
            var entity = model.ToEntity();
            PrepareCreate(entity);
            return Add(entity);
        }

        // Delete Answer
        public void DeleteAnswer(Answer entity)
        {
            Delete(entity);
        }

        // Get Answer By Id
        public Answer GetAnswerById(int id)
        {
            return GetById(id);
        }

        public Answer UpdateAnswer(RequestUpdateAnswer model)
        {
            var entity = model.ToEntity();
            PrepareUpdate(entity);
            return Add(entity);
        }

        public IList<Answer> GetAnswersByQuestionId(int questionId)
        {
            IList<Answer> listAnswer = new List<Answer>();
            foreach (var item in GetAll())
            {
                if(item.QuestionId == questionId)
                {
                    listAnswer.Add(item);
                }
            }
            return listAnswer;
        }
    }
}
