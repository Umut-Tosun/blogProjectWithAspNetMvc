using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace blogProject.Controllers
{
   [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author author)
        {
            var userInfo = c.Author.FirstOrDefault(x => x.Mail == author.Mail && x.Password == author.Password);
            if(userInfo!=null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.Mail,false);
                Session["Mail"]=userInfo.Mail.ToString();
                return RedirectToAction("Index","User");
            }
            else
            {
                 return RedirectToAction("AuthorLogin","Login");
            }       
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var userInfo = c.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.UserName, false);
                Session["Mail"] = userInfo.UserName.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
        }
    }
}