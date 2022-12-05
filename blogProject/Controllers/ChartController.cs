using blogProject.Models;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogProject.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeResult()
        {
            return Json(blogsRatingList(),JsonRequestBehavior.AllowGet);
        }
        public List<Class1> categoryList()
        {
            List<Class1> c = new List<Class1>();
            c.Add(new Class1()
            {
                CategoryName="Yazılım",
                BlogCount=12
            });
            c.Add(new Class1()
            {
                CategoryName = "Oyun",
                BlogCount = 6
            });
            return c;
        }
        public List<BlogsRating> blogsRatingList()
        {
            List<BlogsRating> blogsRating = new List<BlogsRating>();
            using(var c=new Context())
            {
                blogsRating = c.Blogs.Select(x => new BlogsRating
                {
                    BlogName=x.Title,
                    BlogRating=x.BlogRating
                }).ToList();
            }
            return blogsRating;
        }
    }
}