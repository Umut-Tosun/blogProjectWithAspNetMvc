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
    [AllowAnonymous]
    public class SubscribeMailController : Controller
    {
        SubscribeMailManager sMailManager = new SubscribeMailManager(new EfSubscribeMailDal());
        [HttpGet]
        public PartialViewResult add()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult add(SubscribeMail smail)
        {
            sMailManager.Tadd(smail);
            return PartialView();
        }
    }
}