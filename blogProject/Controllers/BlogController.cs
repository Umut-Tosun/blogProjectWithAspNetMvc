using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogProject.Controllers
{
   
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var blogs = blogManager.GetBlogByCategory(id);
            ViewBag.categoryName = blogManager.GetBlogByCategory(id).Select(y => y.Category.Name).FirstOrDefault();
            ViewBag.categoryDescription = blogManager.GetBlogByCategory(id).Select(y => y.Category.Description).FirstOrDefault();
            return View(blogs);
        }
        public ActionResult AdminBlogList()
        {
            var blogList = blogManager.TgetList().OrderByDescending(y => y.DateTime).ToList();
            return View(blogList);
        }
        public ActionResult BlogListByCategory(int id)
        {
            var blogList = blogManager.GetBlogByAuthor(id).OrderByDescending(x=>x.DateTime);
            ViewBag.authorFullName = authorManager.TgetList().Where(x=>x.AuthorID==id).Select(x=>x.FirstName+" "+x.LastName).FirstOrDefault();
            return View(blogList);
        }
        [HttpGet]
        public ActionResult NewBlog()
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
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewBlog(Blog blog)
        {
            blog.ImageUrl = "test.png";
            blog.DateTime = DateTime.Now;
            blogManager.Tadd(blog);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            Blog blog = blogManager.TgetById(id);
            blogManager.Tdelete(blog);
            return RedirectToAction("AdminBlogList");
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
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
        public ActionResult UpdateBlog(Blog blog)
        {
            blogManager.Tupdate(blog);
            return RedirectToAction("AdminBlogList");
        }
        #region BlogPartial
        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {
            var blogs = blogManager.TgetList().ToPagedList(page, 6);
            return PartialView(blogs);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {

            ViewBag.firstPostTitle = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 5).Select(y => y.Title).FirstOrDefault();
            ViewBag.firstPostImageUrl = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 5).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.firstPostDate = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 5).Select(y => y.DateTime).FirstOrDefault();
            ViewBag.firstPostId = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.secondPostTitle = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 3).Select(y => y.Title).FirstOrDefault();
            ViewBag.secondPostImageUrl = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 3).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.secondPostDate = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 3).Select(y => y.DateTime).FirstOrDefault();
            ViewBag.secondPostId = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.thirdPostTitle = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 2).Select(y => y.Title).FirstOrDefault();
            ViewBag.thirdPostImageUrl = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 2).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.thirdPostDate = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 2).Select(y => y.DateTime).FirstOrDefault();
            ViewBag.thirdPostId = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.fourthPostTitle = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 4).Select(y => y.Title).FirstOrDefault();
            ViewBag.fourthPostImageUrl = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 4).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.fourthPostDate = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 4).Select(y => y.DateTime).FirstOrDefault();
            ViewBag.fourthPostId = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.fifthPostTitle = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 6).Select(y => y.Title).FirstOrDefault();
            ViewBag.fifthPostImageUrl = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 6).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.fifthPostDate = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 6).Select(y => y.DateTime).FirstOrDefault();
            ViewBag.fifthPostId = blogManager.TgetList().OrderByDescending(y => y.BlogID).Where(x => x.CategoryID == 6).Select(y => y.BlogID).FirstOrDefault();

            return PartialView();
        }



        /* Blog Details */
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var blogdetails = blogManager.GetBlogByID(id);
            return PartialView(blogdetails);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var blogdetails = blogManager.GetBlogByID(id);
            return PartialView(blogdetails);
        }
        #endregion
        [AllowAnonymous]
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager(new EfCommentDal());
            var commentList = cm.GetCommentByBlog(id).OrderByDescending(x=>x.DateTime);
            ViewBag.blogName = cm.GetCommentByBlog(id).Select(x => x.Blog.Title).FirstOrDefault();
            return View(commentList);
        }
    }
}