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
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            contact.dateTime = DateTime.Now;
            contact.isRead = false;
            contactManager.Tadd(contact);
            return View();
        }
        public ActionResult SendBox()
        {
            var values = contactManager.TgetList().Where(x => x.isRead == false).OrderByDescending(x=>x.dateTime).ToList();
            return View(values);
        }
        public ActionResult SendBox2()
        {
            var values = contactManager.TgetList().Where(x => x.isRead == true).OrderByDescending(x => x.dateTime).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult MessageDetails(int id)
        {
            Contact contact = contactManager.TgetById(id);
            return View(contact);
        }
        [HttpPost]
        public ActionResult MessageDetails(Contact contact)
        {
            contactManager.Tupdate(contact);
            return RedirectToAction("SendBox2");
        }
    }
}