using FPTCertification.Business.Models;
using FPTCertification.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Business.Services
{
    public class CategoryServices : BaseService<Category, int>
    {
        public CategoryServices(DataContext context) : base(context)
        {
        }

        public void PrepareCreate(Category entity)
        {

        }

        public void PrepareUpdate(Category entity)
        {

        }

        public IEnumerable<Category> GetCategories()
        {
            return GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return GetById(id);
        }

        public Category CreateCategory(RequestCreateCategory model)
        {
            var entity = model.ToEntity();
            PrepareCreate(entity);
            return Add(entity);
        }

        public Category UpdateCategory(Category entity)
        {
            PrepareUpdate(entity);
            return Update(entity);
        }

        public Category DeleteCategory(Category entity)
        {
            return Delete(entity);
        }


    }
}
