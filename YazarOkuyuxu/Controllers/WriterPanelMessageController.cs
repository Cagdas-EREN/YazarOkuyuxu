using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YazarOkuyuxu.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.GetAllInbox(p);
            ViewBag.receiver = messageList.Count();
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        { 
            string p = (string)Session["WriterMail"];
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

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.GetAllSendbox(p);
            return View(messageList);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        public ActionResult GetSendMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string sender = (string)Session["WriterMail"];

            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = sender;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                messageManager.Add(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}