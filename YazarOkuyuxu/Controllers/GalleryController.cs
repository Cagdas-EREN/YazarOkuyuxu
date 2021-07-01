using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YazarOkuyuxu.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery

        private ImageFileManager ımageFileManager = new ImageFileManager(new EfImageDal());

        public ActionResult Index()
        {
            var files = ımageFileManager.GetAll();
            return View(files);
        }
    }
}