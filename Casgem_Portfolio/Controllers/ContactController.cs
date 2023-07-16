using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class ContactController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblMessage p)
        {
            db.TblMessage.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Portfolio");
        }

        public PartialViewResult Contact()
        {
            ViewBag.telephoneNumber = db.TblContact.Select(x => x.TelephoneNumber).FirstOrDefault();
            ViewBag.eMail = db.TblContact.Select(x => x.Mail).FirstOrDefault();
            ViewBag.locationContents = db.TblContact.Select(x => x.LocationContents).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialSocialMedia()
        {
            ViewBag.instagram = db.TblSocialMedia.Select(x => x.Instagram).FirstOrDefault();
            ViewBag.facebook = db.TblSocialMedia.Select(x => x.Facebook).FirstOrDefault();
            ViewBag.github = db.TblSocialMedia.Select(x => x.GitHub).FirstOrDefault();
            ViewBag.linkedin = db.TblSocialMedia.Select(x => x.LinkedIn).FirstOrDefault();
            ViewBag.twitter = db.TblSocialMedia.Select(x => x.Twitter).FirstOrDefault();
            return PartialView();
        }
    }
}