using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Utilities;

namespace YazarOkuyuxu.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager adminManager = new AdminManager(new EfAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            string password = admin.AdminPassword.Trim();
            string hasPasword = new CryptoHelper().ComputeSha256Hash(password); 

            var adminInfo = adminManager.GetList().FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == hasPasword);

            if (adminInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminInfo.AdminUserName, false);
                Session["AdminUserName"] = adminInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}