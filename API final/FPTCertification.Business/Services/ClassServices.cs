using FPTCertification.Business.Models;
using FPTCertification.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Services
{
    public class ClassServices : BaseService<Classes, int>
    {
        public ClassServices(DataContext context) : base(context)
        {
        }

        // Automatic Add CreateDate & ModifyDate before create new class
        public void PrepareCreate(Classes entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.ModifyDate = DateTime.Now;
            entity.Activated = true;
        }

        // Automatic update modify date before update a class
        public void PrepareUpdate(Classes entity)
        {
            entity.ModifyDate = DateTime.Now;
        }

        // Create new Class
        public Classes CreateClasses(RequestCreateClasses model)
        {
            var entity = model.ToEntity();
            PrepareCreate(entity);
            return Add(entity);
        }

        // Delete a Class
        public Classes DeleteClasses(Classes _entity)
        {
            return Delete(_entity);
        }

        // Get Class By Id
        public Classes GetClassById(int id)
        {
            return GetById(id);
        }

        // Get all Classes
        public IEnumerable<Classes> GetAllClasses()
        {
            return GetAll();
        }

        // Update a Class
        public Classes UpdateClasses(Classes entity)
        {
            PrepareUpdate(entity);
            return Update(entity);
        }

        // Get Classes By Name
        public IList<Classes> GetClassesByName(string name)
        {
            IList<Classes> list = new List<Classes>();
            foreach(var item in GetAllClasses())
            {
                if (item.Name.Contains(name.ToLower()))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        // Update Status
        public Classes ChangeStatus(RequestUpdateStatusClass model)
        {
            var entity = GetClassById(model.Id);
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
