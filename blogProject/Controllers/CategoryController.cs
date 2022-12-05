using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager CategoryManager = new CategoryManager(new EfCategoryDal());
        CategoryValidator validationRules = new CategoryValidator();
        public ActionResult Index()
        {
            var categories = CategoryManager.TgetList();
            return View(categories);
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategories()
        {
            var categories = CategoryManager.TgetList();
            return PartialView(categories);
        }
        public ActionResult CategoryList()
        {
            var categories = CategoryManager.TgetList();

            return View(categories);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            category.Status = true;
            ValidationResult results = validationRules.Validate(category);
            if (results.IsValid)
            { 
                CategoryManager.Tadd(category);
                return RedirectToAction("CategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
           
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            Category category = CategoryManager.TgetById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            ValidationResult results = validationRules.Validate(category);
            if (results.IsValid)
            {
                CategoryManager.Tupdate(category);
                return RedirectToAction("CategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(category);
        }
        public ActionResult ChangeStatusCategory(int id)
        {
            Category category = CategoryManager.TgetById(id);
            if (category.Status == true) category.Status = false;
            else category.Status = true;

            CategoryManager.Tupdate(category);
            return RedirectToAction("CategoryList");
        }
    }
}