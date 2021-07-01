using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YazarOkuyuxu.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetAll();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(About about)
        {
            aboutManager.Add(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult Delete(int id)
        {
            var aboutValue = aboutManager.GetById(id);
            aboutManager.Delete(aboutValue);

            return RedirectToAction("Index");
        }

    }
}