using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace blogProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        [HttpGet]
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            // var profileValues = userManager.GetAuthorByMail(mail);
            Author author = authorManager.TgetList().Where(x => x.Mail == mail).FirstOrDefault();
            return View(author);
        }
        [HttpPost]
        public ActionResult UpdateUser(Author author)
        {
            authorManager.Tupdate(author);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList()
        {
            var mail = (string)Session["Mail"];
            // var profileValues = userManager.GetAuthorByMail(mail);
            int authorID = authorManager.TgetList().Where(x => x.Mail == mail).Select(y => y.AuthorID).FirstOrDefault();
            var values = blogManager.GetBlogByAuthor(authorID).OrderBy(x => x.DateTime);
            return View(values);
        }
        [HttpGet]
        public ActionResult BlogDetails(int id)
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            List<SelectListItem> values2 = (from x in c.Author.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.FirstName + " " + x.LastName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.Categories = values;
            ViewBag.Authors = values2;


            Blog blog = blogManager.TgetById(id);
            return View(blog);
        }
        [HttpPost]
        public ActionResult BlogDetails(Blog blog)
        {
            blogManager.Tupdate(blog);
            return RedirectToAction("BlogList");
        }
        [HttpGet]
        public ActionResult AddBlog()
        {
            Context c = new Context();
            List<SelectListItem> categories = (from x in c.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();

            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult AddBlog(Blog blog)
        {
            var mail = (string)Session["Mail"];
            int authorID = authorManager.TgetList().Where(x => x.Mail == mail).Select(y => y.AuthorID).FirstOrDefault();
            blog.AuthorID = authorID;
            blog.ImageUrl = "test.png";
            blog.DateTime = DateTime.Now;
            blogManager.Tadd(blog);
            return RedirectToAction("BlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            Blog blog = blogManager.TgetById(id);
            blogManager.Tdelete(blog);
            return RedirectToAction("BlogList");
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public PartialViewResult LastBlogs()
        {
            var mail = (string)Session["Mail"];
            // var profileValues = userManager.GetAuthorByMail(mail);
            int authorID = authorManager.TgetList().Where(x => x.Mail == mail).Select(y => y.AuthorID).FirstOrDefault();

            var values = blogManager.GetBlogByAuthor(authorID).OrderBy(x => x.DateTime);

            if (values.Count() > 5)
            {
                values = blogManager.GetBlogByAuthor(authorID).Take(5).OrderByDescending(x => x.DateTime);
            }
            return PartialView(values);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin","Login");
        }
    }
}