using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal categoryDal;


        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }
      
        public void Tadd(Category t)
        {
           categoryDal.Insert(t);
        }

        public void Tdelete(Category t)
        {
            categoryDal.Delete(t);
        }

        public void Tupdate(Category t)
        {
            categoryDal.Update(t);
        }

        public List<Category> TgetList()
        {
            return categoryDal.List();
        }

        public Category TgetById(int id)
        {
            return categoryDal.GetByID(id);
        }
    }
}
