using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class AdminContactController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblContact.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.TblContact.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateContact(TblContact p)
        {
            var value = db.TblContact.Find(p.ContactID);
            value.TelephoneNumber = p.TelephoneNumber;
            value.Mail = p.Mail;
            value.LocationContents = p.LocationContents;
            value.Age = p.Age;
            value.Name = p.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteContact(int id)
        {
            var value = db.TblContact.Find(id);
            db.TblContact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet] //sayfa yüklenince
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost] //sayfada butona tıklanınca //parametre vermemiz gerek
        public ActionResult AddProject(TblContact p)
        {
            db.TblContact.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}