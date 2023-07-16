using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class FeatureController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        public ActionResult Index()
        {
            var values = db.TblFeature.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = db.TblFeature.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateFeature(TblFeature p)
        {
            var value = db.TblFeature.Find(p.FeatureID);
            value.FeatureTitle = p.FeatureTitle;
            value.FeatureDescreption = p.FeatureDescreption;
            value.FeatureImageURL = p.FeatureImageURL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteFeature(int id)
        {
            var value = db.TblFeature.Find(id);
            db.TblFeature.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet] //sayfa yüklenince
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost] //sayfada butona tıklanınca //parametre vermemiz gerek
        public ActionResult AddProject(TblFeature p)
        {
            db.TblFeature.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}