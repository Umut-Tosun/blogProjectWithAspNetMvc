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
    public class BlogManager : IBlogService
    {
        IBlogDal blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            this.blogDal = blogDal;
        }

        public List<Blog> GetBlogByID(int id)
        {
            return blogDal.List(x => x.BlogID == id);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return blogDal.List(x => x.AuthorID == id);
        }
        public List<Blog> GetBlogByCategory(int id)
        {
            return blogDal.List(x => x.CategoryID == id);
        }    
       
        public void Tadd(Blog t)
        {
            blogDal.Insert(t);
        }

        public void Tdelete(Blog t)
        {
            blogDal.Delete(t);
        }

        public void Tupdate(Blog t)
        {
            blogDal.Update(t);
        }

        public List<Blog> TgetList()
        {
           return blogDal.List();
        }

        public Blog TgetById(int id)
        {
            return blogDal.Find(x=>x.BlogID==id);
        }
    }
}
