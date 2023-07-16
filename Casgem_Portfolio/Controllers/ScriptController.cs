using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class ScriptController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        public ActionResult Index()
        {
            var values = db.TblScript.ToList();
            return View(values);
        }
        [HttpGet] //sayfa yüklenince
        public ActionResult AddScript()
        {
            return View();
        }
        [HttpPost] //sayfada butona tıklanınca //parametre vermemiz gerek
        public ActionResult AddScript(TblScript p)
        {
            db.TblScript.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteScript(int id)
        {
            var value = db.TblScript.Find(id);
            db.TblScript.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateScript(int id)
        {
            var value = db.TblScript.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateScript(TblScript p)
        {
            var value = db.TblScript.Find(p.ScriptID);
            value.Script1 = p.Script1;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}