using AltWebsite.Models;
using System;
using System.Data;
using System.Linq;
using System.Net;
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

        public ActionResult Bookings(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var selectedTourist = _db.Tourists.Find(id);

            if (selectedTourist == null) return HttpNotFound();

            return View(selectedTourist);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Comments, Review")]Tourist tourist)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Tourists.Add(tourist);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.Try again, and if the problem persists see your system administrator.");
            }

            return View(tourist);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var touristToUpdate = _db.Tourists.Find(id);
            return View(touristToUpdate);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var touristToUpdate = _db.Tourists.Find(id);

            if (touristToUpdate == null) return HttpNotFound();

            if (TryUpdateModel( touristToUpdate, "", new string[] { "Comments", "Review" }))
            {
                try
                {
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes.Try again, and if the problem persists see your system administrator.");
                }
            }

            return View(touristToUpdate);
        }

        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if(saveChangesError.GetValueOrDefault())
            {
                ViewBag.Message = "Your application description page.Try again, and if the problem persists see your system administrator.";
            }

            var touristToBeDeleted = _db.Tourists.Find(id);

            return View(touristToBeDeleted);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            try
            {
                var touristToBeDeleted = _db.Tourists.Find(id);
                _db.Tourists.Remove(touristToBeDeleted);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
                throw;
            }
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