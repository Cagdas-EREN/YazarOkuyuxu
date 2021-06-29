using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;

namespace YazarOkuyuxu.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());
        private WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index(string sortOrder, string searchString)
        {
            var cats = cm.GetAll();
            var writers = wm.GetList();
            var headers = hm.GetAll();
            ViewBag.categoryCount = cats.Count();
            ViewBag.yazilimCount = headers.Where(x => x.CategoryId == 9).Count();
            ViewBag.writerCountName = writers.Where(x => x.WriterName.Contains("a")).Count();

            #region En fazla başlığa sahip kategori adı
            var grouped = from h in headers
                          group h by h.CategoryId into g
                          select new { Id = g.Key, Count = g.Count() };

            var query = grouped.OrderByDescending(x => x.Count).First().Id;
            var cat = cats.Where(x => x.CategoryId == query).SingleOrDefault();
            ViewBag.maxHeaders = cat.CategoryName;
            #endregion

            #region True olan kategoriler ile false olan kategoriler arasındaki sayısal fark

            var trues = cats.Where(x => x.Status == true);
            var falses = cats.Where(x => x.Status == false);

            var diff = trues.Count() - falses.Count();
            ViewBag.catStatus = diff;

            #endregion
            return View();
        }
    }
}