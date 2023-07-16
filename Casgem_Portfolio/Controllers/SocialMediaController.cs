using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        public ActionResult Index()
        {
            var value = db.TblSocialMedia.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult UpdateSocial(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocial(TblSocialMedia p)
        {
            var value = db.TblSocialMedia.Find(p.SocialMediaID);
            value.Instagram = p.Instagram;
            value.Facebook = p.Facebook;
            value.LinkedIn = p.LinkedIn;
            value.GitHub = p.GitHub;
            value.Twitter = p.Twitter;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}