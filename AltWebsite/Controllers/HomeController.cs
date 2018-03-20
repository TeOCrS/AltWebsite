using AltWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltWebsite.Controllers
{
    public class HomeController : Controller
    {
        private AltWebsiteDb _db = new AltWebsiteDb();

        public ActionResult Index()
        {
            var info = _db.Tourists.ToList();
            return View(info);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

           return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}