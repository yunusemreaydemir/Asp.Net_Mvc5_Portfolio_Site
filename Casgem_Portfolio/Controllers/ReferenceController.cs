using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;


namespace Casgem_Portfolio.Controllers
{
    public class ReferenceController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblReference.ToList();
            return View(values);
        }
        public ActionResult DeleteReference(int id)
        {
            var value = db.TblReference.Find(id);
            db.TblReference.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateReference(int id)
        {
            var value = db.TblReference.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateReference(TblReference p)
        {
            var value = db.TblReference.Find(p.ReferenceID);
            value.NameSurname = p.NameSurname;
            value.Mail = p.Mail;
            value.ContactNumber = p.ContactNumber;
            value.Job = p.Job;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet] //sayfa yüklenince
        public ActionResult AddReference()
        {
            return View();
        }
        [HttpPost] //sayfada butona tıklanınca //parametre vermemiz gerek
        public ActionResult AddReference(TblReference p)
        {
            db.TblReference.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}