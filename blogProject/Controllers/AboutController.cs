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
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            var about = aboutManager.TgetList();
            return View(about);
        }
        [AllowAnonymous]
        public PartialViewResult Footer()
        {
            var about = aboutManager.TgetList();
            return PartialView(about);
        }
        [AllowAnonymous]
        public PartialViewResult MeetTheTeam()
        {
            var team = authorManager.TgetList();
            return PartialView(team);
        }
        [HttpGet]
        public ActionResult UpdateAbout()
        {
            var values = aboutManager.TgetList();
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAboutPost(About p)
        { 
            aboutManager.Tupdate(p);
            return RedirectToAction("UpdateAbout");
        }
    }
}