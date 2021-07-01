using Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.ValidationRules.FluentValidation;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;

namespace YazarOkuyuxu.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        private CategoryManager cm = new CategoryManager(new EfCategoryDal());

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var category = cm.GetAll();
            return View(category);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            //cm.Add(category);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);

            if (result.IsValid)
            {
                cm.Add(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


    }
}