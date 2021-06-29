using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;

namespace YazarOkuyuxu.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        private HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        private CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        private WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var heading = headingManager.GetAll();
            return View(heading);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> categoryList = (from x in categoryManager.GetAll()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();
            List<SelectListItem> writerList = (from x in writerManager.GetList()
                select new SelectListItem
                {
                    Text = x.WriterName + " " + x.WriterSurName,
                    Value = x.WriterId.ToString()
                }).ToList();
            ViewBag.vlc = categoryList;
            ViewBag.vlw = writerList;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.Add(heading);
            return RedirectToAction("Index");
        }
        public ActionResult ContentByHeading()
        {
            return View();
        }
    }
}