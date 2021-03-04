using FPTCertification.Business.Models;
using FPTCertification.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Services
{
    public class QuestionServices : BaseService<Question, int>
    {
        private readonly AnswerServices answerServices;

        public QuestionServices(DataContext context) : base(context)
        {
            answerServices = new AnswerServices(context);
        }

        public void PrepareCreate(Question entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.ModifyDate = DateTime.Now;
            entity.Activated = true;
        }

        public void PrepareUpdate(Question entity)
        {
            entity.ModifyDate = DateTime.Now;
        }

        public Question GetQuestionById(int id)
        {
            return GetById(id);
        }

        public Question CreateQuestion(RequestCreateQuestion model)
        {
            var entity = model.ToEntity();
            PrepareCreate(entity);
            Question question = Add(entity);
            Commit();
            IList<Answer> listAnswer = new List<Answer>();
            foreach (var item in model.Answers)
            {
                Answer ans = answerServices.CreateAnswer(item);
                ans.QuestionId = question.Id;
                listAnswer.Add(ans);
                Commit();
            }
            question.Answers = listAnswer;
            return question;
        }

        public Question UpdateQuestion(RequestUpdateQuestion model)
        {
            var entity = model.ToEntity();
            entity.Answers = answerServices.GetAnswersByQuestionId(model.Id);
            PrepareUpdate(entity);
            Question question = Update(entity);
            foreach (var item in entity.Answers)
            {
                if (item.QuestionId == model.Id)
                {
                    answerServices.DeleteAnswer(item);
                }
            }
            foreach (var item in model.Answers)
            {
                Answer ans = answerServices.UpdateAnswer(item);
                ans.QuestionId = question.Id;
                question.Answers.Add(ans);
            }
            Commit();
            return question;
        }

    }
}
