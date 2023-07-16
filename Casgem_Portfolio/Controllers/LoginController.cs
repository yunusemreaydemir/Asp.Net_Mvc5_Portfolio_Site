using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Casgem_Portfolio.Controllers
{
    
    [AllowAnonymous]
    public class AdminController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login p)
        {
            CasgemPortfolioEntities db = new CasgemPortfolioEntities();
            var user = db.Login.FirstOrDefault(x => x.Admin == p.Admin && x.Password == p.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Admin, false);
                Session["Admina"] = user.Admin.ToString();
                return RedirectToAction("Index", "Skills");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Admin");
        }
    }
}