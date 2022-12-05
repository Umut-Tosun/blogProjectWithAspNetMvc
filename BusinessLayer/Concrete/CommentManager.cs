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
    public class CommentManager : ICommentService
    {
        ICommentDal commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            this.commentDal = commentDal;
        }

        public List<Comment> GetCommentByBlog(int id)
        {
            return commentDal.List(x => x.BlogID == id);
        }

        public void Tadd(Comment t)
        {
            commentDal.Insert(t);
        }

        public void Tdelete(Comment t)
        {
            throw new NotImplementedException();
        }

        public void Tupdate(Comment t)
        {
            commentDal.Update(t);
        }

        public List<Comment> TgetList()
        {
            return commentDal.List();
        }

        public Comment TgetById(int id)
        {
            return commentDal.Find(x=>x.ID==id);
        }
    }
}
