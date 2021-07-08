using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YazarOkuyuxu.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator contactValidator = new ContactValidator();

        public ActionResult Index()
        {
            var contactValues = contactManager.GetAll();
            ViewBag.contact = contactValues.Count();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult MessageListMenu(string p)
        {
            var contactValues = contactManager.GetAll();
            ViewBag.contact = contactValues.Count();

            var messageList = messageManager.GetAllInbox(p);
            ViewBag.receiver = messageList.Count();

            var messagecount = messageManager.GetAllSendbox(p);
            ViewBag.sendvalue = messagecount.Count();

            var draftValue = messageManager.GetAllDraft();
            ViewBag.draftValue = draftValue.Count();

            var unReadValue = messageManager.UnReadList().Count();
            ViewBag.unReadValue = unReadValue;

            var readValue = messageManager.ReadList().Count();
            ViewBag.readValue = readValue;

            return PartialView();
        }
    }
}