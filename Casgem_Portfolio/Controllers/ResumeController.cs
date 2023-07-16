using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class ResumeController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        public ActionResult Index()
        {
            var values = db.TblResume.ToList();
            return View(values);
        }
        [HttpGet] //sayfa yüklenince
        public ActionResult AddResume()
        {
            return View();
        }
        [HttpPost] //sayfada butona tıklanınca //parametre vermemiz gerek
        public ActionResult AddResume(TblResume p)
        {
            db.TblResume.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteResume(int id)
        {
            var value = db.TblResume.Find(id);
            db.TblResume.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateResume(int id)
        {
            var value = db.TblResume.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateResume(TblResume p)
        {
            var value = db.TblResume.Find(p.ResumeID);
            value.Title1 = p.Title1;
            value.Title2 = p.Title2;
            value.Descreption = p.Descreption;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}