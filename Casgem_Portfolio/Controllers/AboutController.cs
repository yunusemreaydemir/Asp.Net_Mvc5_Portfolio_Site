using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class AboutController : Controller

    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialStatistic()
        {
            var values = db.TblStatistic.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialProject()
        {
            var values = db.TblProject.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAbout()
        {

            var values = db.TblAbout.FirstOrDefault();
            ViewBag.contentsName = db.TblContact.Select(x => x.Name).FirstOrDefault();
            ViewBag.contentsAge = db.TblContact.Select(x => x.Age).FirstOrDefault();
            ViewBag.contetsLocation = db.TblContact.Select(x => x.LocationContents).FirstOrDefault();
            ViewBag.contentsMail = db.TblContact.Select(x => x.Mail).FirstOrDefault();
            SocialMEdia();
            return PartialView(values);
        }
        public PartialViewResult PartialSkills()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSection()
        {
            return PartialView();
        }
        public PartialViewResult PartialSocialMedia()
        {
            SocialMEdia();
            return PartialView();
        }

        public void SocialMEdia()
        {
            ViewBag.instagram = db.TblSocialMedia.Select(x => x.Instagram).FirstOrDefault();
            ViewBag.facebook = db.TblSocialMedia.Select(x => x.Facebook).FirstOrDefault();
            ViewBag.github = db.TblSocialMedia.Select(x => x.GitHub).FirstOrDefault();
            ViewBag.linkedin = db.TblSocialMedia.Select(x => x.LinkedIn).FirstOrDefault();
            ViewBag.twitter = db.TblSocialMedia.Select(x => x.Twitter).FirstOrDefault();
        }
    }
}