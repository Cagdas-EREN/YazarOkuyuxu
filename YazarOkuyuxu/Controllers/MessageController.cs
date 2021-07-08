using Business.Concrete;
using Business.ValidationRules.FluentValidation;
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
    public class MessageController : Controller
    {
        // GET: Message

        MessageManager messageManager  = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messageList = messageManager.GetAllInbox(p);
            ViewBag.receiver = messageList.Count();
            return View(messageList);
        }

        public ActionResult Sendbox(string p)
        {
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
            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
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

        [HttpPost]
        public ActionResult AddDraft(Message message)
        {
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
            messageManager.AddDraft(message);
            return RedirectToAction("Inbox");
        }

        public ActionResult GetAllDraft()
        {
            var message = messageManager.GetAllDraft();
            return View(message);
        }

        public ActionResult ListReadMessage()
        {
            var message = messageManager.ReadList();
            return View(message);
        }
        public ActionResult ListUnReadMessage()
        {
            var message = messageManager.UnReadList();
            return View(message);
        }
        public ActionResult ReadMessage(int id)
        {
            var message = messageManager.GetById(id);
            messageManager.ReadStatus(message);
            return RedirectToAction("ListUnReadMessage");
        }
    }
}