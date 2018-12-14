using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _TrashCollector_DCC.Models;

namespace _TrashCollector_DCC.Controllers
{
    public class WeeklyPickupDaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WeeklyPickupDays
        public ActionResult Index()
        {
            var weeklyPickupDays = db.WeeklyPickupDays.Include(w => w.Customers);
            return View(weeklyPickupDays.ToList());
        }

        // GET: WeeklyPickupDays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyPickupDay weeklyPickupDay = db.WeeklyPickupDays.Find(id);
            if (weeklyPickupDay == null)
            {
                return HttpNotFound();
            }
            return View(weeklyPickupDay);
        }

        // GET: WeeklyPickupDays/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName");
            return View();
        }

        // POST: WeeklyPickupDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,WeeklyPickUpDay,WeeklyPickUpDayCompleted,Balance")] WeeklyPickupDay weeklyPickupDay)
        {
            if (ModelState.IsValid)
            {
                db.WeeklyPickupDays.Add(weeklyPickupDay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", weeklyPickupDay.CustomerId);
            return View(weeklyPickupDay);
        }

        // GET: WeeklyPickupDays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyPickupDay weeklyPickupDay = db.WeeklyPickupDays.Find(id);
            if (weeklyPickupDay == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", weeklyPickupDay.CustomerId);
            return View(weeklyPickupDay);
        }

        // POST: WeeklyPickupDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,WeeklyPickUpDay,WeeklyPickUpDayCompleted,Balance")] WeeklyPickupDay weeklyPickupDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weeklyPickupDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", weeklyPickupDay.CustomerId);
            return View(weeklyPickupDay);
        }

        // GET: WeeklyPickupDays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyPickupDay weeklyPickupDay = db.WeeklyPickupDays.Find(id);
            if (weeklyPickupDay == null)
            {
                return HttpNotFound();
            }
            return View(weeklyPickupDay);
        }

        // POST: WeeklyPickupDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeeklyPickupDay weeklyPickupDay = db.WeeklyPickupDays.Find(id);
            db.WeeklyPickupDays.Remove(weeklyPickupDay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
