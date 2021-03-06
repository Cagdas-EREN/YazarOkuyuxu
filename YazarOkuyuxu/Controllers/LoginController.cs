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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        private WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterDal());

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

            var adminInfo = adminManager.GetAll().FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == hasPasword);

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

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            //string password = writer.WriterPassword.Trim();
            //string hasPasword = new CryptoHelper().ComputeSha256Hash(password);

            var WriterUserİnfo = writerLoginManager.GetWriter(writer.WriterMail, writer.WriterPassword);

            if (WriterUserİnfo != null)
            {
                FormsAuthentication.SetAuthCookie(WriterUserİnfo.WriterMail, false);
                Session["WriterMail"] = WriterUserİnfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");
        }
    }
}