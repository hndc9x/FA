using FPTCertification.Business.Models;
using FPTCertification.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Services
{
    public class QuestionTypeServices : BaseService<QuestionType, string>
    {
        public QuestionTypeServices(DataContext context) : base(context)
        {   
        }

        public void PrepareCreate(QuestionType entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.ModifyDate = DateTime.Now;
            entity.Activated = true;
        }

        public void PrepareUpdate(QuestionType entity)
        {
            entity.ModifyDate = DateTime.Now;
        }

        public QuestionType CreateQuestionType(RequestCreateQuestionType model)
        {
            var entity = model.ToEntity();
            PrepareCreate(entity);
            return Add(entity);
        }

        public IEnumerable<QuestionType> GetAllQuestionType()
        {
            return GetAll();
        }
    }
}
