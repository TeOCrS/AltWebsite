using AltWebsite.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AltWebsite.Controllers
{
    public class BookingsController : Controller
    {
        private AltWebsiteDb _db = new AltWebsiteDb();

        public ActionResult Bookings()
        {
            var info = _db.Bookings.ToList();
            return View(info);
        }

        public ActionResult Details(int? id)
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
        public ActionResult Create([Bind(Include = "StartDate, EndDate, Website, Tourist, Payment")]Booking booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdTourist = _db.Tourists.Add(booking.Tourist);
                    var createdPayment = _db.Payments.Add(booking.Payment);
                    _db.SaveChanges();

                    booking.TouristId = createdTourist.Id;
                    booking.PaymentId = createdPayment.Id;
                    _db.Bookings.Add(booking);
                    _db.SaveChanges();
                    return RedirectToAction("Bookings");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.Try again, and if the problem persists see your system administrator." + ex.Message);
            }

            return RedirectToAction("Bookings");
        }

        [HttpGet]
        public ActionResult EditBooking(int? id)
        {
            var bookingToUpdate = _db.Bookings.Find(id);
            return View(bookingToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBooking([Bind(Include = "Id, PaymentId, TouristId, StartDate, EndDate, Website, Tourist, Payment")] Booking booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(booking).State = EntityState.Modified;
                    _db.Entry(booking.Payment).State = EntityState.Modified;
                    _db.Entry(booking.Tourist).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Bookings");
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", "Unable to save changes.Try again, and if the problem persists see your system administrator." + ex.Message);
            }

            return View(booking);
        }

        public ActionResult EditPayment(int? id)
        {
            var bookingToUpdate = _db.Bookings.Find(id);
            var paymentToUpdate = _db.Payments.Find(bookingToUpdate.PaymentId);
            return View(paymentToUpdate);
        }

        [HttpPost, ActionName("EditPayment")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPaymentPost([Bind(Include = "Id, PricePerDay, CommisionFee, CleanupFee")] Payment payment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(payment).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Bookings");
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", "Unable to save changes.Try again, and if the problem persists see your system administrator." + ex.Message);
            }

            return View(payment);
        }

        public ActionResult EditTourist(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tourist tourist = _db.Tourists.Find(id);
            if (tourist == null)
            {
                return HttpNotFound();
            }
            return View(tourist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTourist([Bind(Include = "Id, FirstName, LastName, Country, PreferedLanguage, EmailAddress, Comments, Review")] Tourist tourist)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(tourist).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Bookings");
            }
            return View(tourist);
        }

        public ActionResult Tourists()
        {
            return View(_db.Tourists.ToList());
        }

        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.Message = "Your application description page.Try again, and if the problem persists see your system administrator.";
            }

            var bookingToBeDeleted = _db.Bookings.Find(id);

            return View(bookingToBeDeleted);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            try
            {
                var bookingToBeDeleted = _db.Bookings.Find(id);
                _db.Bookings.Remove(bookingToBeDeleted);
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