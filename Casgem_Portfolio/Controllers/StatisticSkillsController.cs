using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class StatisticSkillsController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblStatistic.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddStatistic()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStatistic(TblStatistic p)
        {
            db.TblStatistic.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteStatistic(int id)
        {
            var value = db.TblStatistic.Find(id);
            db.TblStatistic.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateStatistic(int id)
        {
            var value = db.TblStatistic.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateStatistic(TblStatistic p)
        {
            var value = db.TblStatistic.Find(p.StatisticID);
            value.StatisticTitle = p.StatisticTitle;
            value.Percentile = p.Percentile;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}