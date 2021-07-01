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
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox()
        {
            var messageList = messageManager.GetAllInbox();
            ViewBag.receiver = messageList.Count();
            return View(messageList);
        }
    }
}