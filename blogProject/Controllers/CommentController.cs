using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var comments = commentManager.GetCommentByBlog(id).OrderByDescending(x => x.DateTime);
            return PartialView(comments);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.blogID = id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment comment)
        {
            comment.DateTime = DateTime.Now;
            commentManager.Tadd(comment);
            return PartialView();
        }
        public ActionResult AdminCommentList()
        {
            Context c = new Context();
            var comments = commentManager.TgetList().OrderByDescending(x => x.DateTime).Where(x => x.isRead == false).ToList();
            return PartialView(comments);
        }
        public ActionResult AdminisReadTrueCommentList()
        {
            var comments = commentManager.TgetList().OrderByDescending(x => x.DateTime).Where(x => x.isRead == true).ToList();
            return PartialView(comments);
        }
        public ActionResult DeleteComment(int id)
        {
            Comment comment = commentManager.TgetById(id);
            commentManager.Tdelete(comment);
            return RedirectToAction("AdminCommentList");
        }
        public ActionResult UpdateComment(int id)
        {
            Comment comment = commentManager.TgetById(id);
            if (comment.isRead == false) comment.isRead = true;
            else comment.isRead = false;

            commentManager.Tupdate(comment);
            return RedirectToAction("AdminCommentList");
        }
    }
}