using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class AdminAboutController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = db.TblAbout.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(TblAbout p)
        {
            var value = db.TblAbout.Find(p.AboutID);
            value.AboutTitle1 = p.AboutTitle1;
            value.AboutTitle2 = p.AboutTitle2;
            value.AboutContents = p.AboutContents;
            value.Cv = p.Cv;
            value.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}