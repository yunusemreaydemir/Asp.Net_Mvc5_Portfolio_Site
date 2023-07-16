using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature() //ilk sayfa foto
        {
            ViewBag.featureTitle = db.TblFeature.Select(x => x.FeatureTitle).FirstOrDefault(); //sadece bir veri çekmek istersek firstordefault, birden fazla değer ise tolist kullanabiliriz
            ViewBag.featureDescription = db.TblFeature.Select(x => x.FeatureDescreption).FirstOrDefault();
            ViewBag.featureImage = db.TblFeature.Select(x => x.FeatureImageURL).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            {

                var textArray = db.TblScript.Select(x => x.Script1).ToArray();

                ViewBag.script = textArray;

                return PartialView();
            }
        }
        public PartialViewResult MyResume()
        {
            var values = db.TblResume.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialStatistic()
        {
            ViewBag.totalService = db.TblService.Count();
            ViewBag.totalMessage = db.TblMessage.Count();
            ViewBag.totalThanksMessage = db.TblMessage.Where(x => x.MessageSubject == "Teşekkür").Count();
            ViewBag.happyCustomer = db.TblMessage.Count();
            return PartialView();
        }

        public PartialViewResult PartialAboutMe()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestImonial() //referanslarım
        {
            var values = db.TblReference.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialVideo()
        {
            ViewBag.videoTitle = db.TblVideo.Select(x => x.VideoTitle).FirstOrDefault();
            ViewBag.videoContent = db.TblVideo.Select(x => x.VideoContents).FirstOrDefault();
            ViewBag.videoUrl = db.TblVideo.Select(x => x.VideoUrl).FirstOrDefault();
            ViewBag.videoImageUrl = db.TblVideo.Select(x => x.VideoImageUrl).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialServices()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
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