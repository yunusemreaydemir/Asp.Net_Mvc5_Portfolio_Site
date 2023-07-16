using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class SkillsController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblSkills.ToList();
            return View(values);
        }
        [HttpGet] //sayfa yüklenince
        public ActionResult AddSkills()
        {
            return View();
        }
        [HttpPost] //sayfada butona tıklanınca //parametre vermemiz gerek
        public ActionResult AddSkills(TblSkills p)
        {
            db.TblSkills.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkills(int id)
        {
            var value = db.TblSkills.Find(id);
            db.TblSkills.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkills(int id)
        {
            var value = db.TblSkills.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSkills(TblSkills p)
        {
            var value = db.TblSkills.Find(p.SkillsID);
            value.Title1 = p.Title1;
            value.Tite2 = p.Tite2;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}