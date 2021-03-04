using FPTCertification.Business.Models;
using FPTCertification.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Services
{
    public class ExamServices : BaseService<Exam, int>
    {
        private readonly CertificationServices certificationServices;
        public ExamServices(DataContext context) : base(context)
        {
            certificationServices = new CertificationServices(context);
        }

        public void PrepareCreate(Exam entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.ModifyDate = DateTime.Now;
        }

        public void PrepareUpdate(Exam entity)
        {
            entity.ModifyDate = DateTime.Now;
        }

        public IEnumerable<Exam> GetAllExams()
        {
            return GetAll();
        }

        public Exam GetExamById(int id)
        {
            return GetById(id);
        }

        public Exam CreateExam(RequestCreateExam model)
        {
            var entity = model.ToEntity();
            PrepareCreate(entity);
            return Add(entity);
        }

        public Exam UpdateExam(Exam entity)
        {
            PrepareUpdate(entity);
            return Update(entity);
        }

        public Exam DeleteExam(Exam entity)
        {
            return Delete(entity);
        }
        public IList<Exam> GetCertificateById(int id)
        {
            List<Exam> list = new List<Exam>();
            Certification _certificate = certificationServices.GetCertificationById(id);
            foreach (var item in GetAllExams())
            {
                if (item.CertificationId.Equals(_certificate.Id))
                {
                    list.Add(item);
                }
            }
            return list;
        }



    }
}
