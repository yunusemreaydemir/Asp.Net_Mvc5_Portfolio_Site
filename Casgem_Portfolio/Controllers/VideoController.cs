using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class VideoController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblVideo.ToList();
            return View(values);
        }
               
        [HttpGet]
        public ActionResult UpdateVideo(int id)
        {
            var value = db.TblVideo.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateVideo(TblVideo p)
        {
            var value = db.TblVideo.Find(p.VideoID);
            value.VideoTitle = p.VideoTitle;
            value.VideoContents = p.VideoContents;
            value.VideoUrl = p.VideoUrl;
            value.VideoImageUrl = p.VideoImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}