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
   public class AuthorManager : IAuthorService
    {
        IAuthorDal authorDal;
       

        public AuthorManager(IAuthorDal authorDal)
        {
            this.authorDal = authorDal;
        }

      
        public void Tadd(Author t)
        {
            authorDal.Insert(t);
        }

        public void Tdelete(Author t)
        {
            authorDal.Delete(t);
        }

        public void Tupdate(Author t)
        {
            authorDal.Update(t);
        }

        public List<Author> TgetList()
        {
            return authorDal.List();
        }

        public Author TgetById(int id)
        {
            return authorDal.Find(x=>x.AuthorID==id);
        }
    }
}
