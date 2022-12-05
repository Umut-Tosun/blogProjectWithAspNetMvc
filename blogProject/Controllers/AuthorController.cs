using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogProject.Controllers
{
    public class AuthorController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        [AllowAnonymous]
        public PartialViewResult About(int id)
        {
            var values = blogManager.GetBlogByID(id);
            return PartialView(values);
        }
        [AllowAnonymous]
        public PartialViewResult PopularPosts(int id)
        {
            var blogAuthorID = blogManager.TgetList().Where(x=>x.BlogID==id).Select(x=>x.AuthorID).FirstOrDefault();
            var blogs = blogManager.GetBlogByAuthor(blogAuthorID).OrderByDescending(x=>x.DateTime);
            return PartialView(blogs);
        }
        public ActionResult AuthorList()
        {
            var authors = authorManager.TgetList();
            return View(authors);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            author.ImageUrl = "https://i.hizliresim.com/itfiq05.png";
            authorManager.Tadd(author);
            return RedirectToAction("AuthorList");
        }
        [HttpGet]
        public ActionResult UpdateAuthor(int id)
        {
            Author author = authorManager.TgetById(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult UpdateAuthor(Author author)
        {
          
            authorManager.Tupdate(author);
            return RedirectToAction("AuthorList");
        }
    }
}