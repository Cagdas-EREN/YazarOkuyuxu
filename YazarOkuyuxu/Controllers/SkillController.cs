using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YazarOkuyuxu.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill

        SkillManager skillManager = new SkillManager(new EfSkillDal());

        public ActionResult Index()
        {
            var skill = skillManager.GetList();
            return View(skill);
        }
    }
}