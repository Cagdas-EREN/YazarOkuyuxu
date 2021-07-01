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
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        private HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        private CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult WriterProfile()
        {
            return View();
        }

        
        public ActionResult MyHeading()
        {
            var values = headingManager.GetAllByWriter();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categoryList = (from x in categoryManager.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.vlc = categoryList;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = 1;
            heading.HeadingStatus = true;
            headingManager.Add(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<SelectListItem> categoryList = (from x in categoryManager.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.vlc = categoryList;

            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult Edit(Heading heading)
        {
            headingManager.Update(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult Delete(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.Delete(headingValue);
            return RedirectToAction("MyHeading");
        }
    }
}