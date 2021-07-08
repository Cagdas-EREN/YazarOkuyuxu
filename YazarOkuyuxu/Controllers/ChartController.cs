using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazarOkuyuxu.Models;

namespace YazarOkuyuxu.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryChart> BlogList()
        {
            List<CategoryChart> categoryCharts = new List<CategoryChart>();
            categoryCharts.Add(new CategoryChart()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            categoryCharts.Add(new CategoryChart()
            {
                CategoryName = "Seyehat",
                CategoryCount = 4
            });
            categoryCharts.Add(new CategoryChart()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 3
            });
            categoryCharts.Add(new CategoryChart()
            {
                CategoryName = "Spor",
                CategoryCount = 9
            });

            return categoryCharts;
        }
    }
}