using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _TrashCollector_DCC.Models;
using Microsoft.AspNet.Identity;

namespace _TrashCollector_DCC.Controllers
{
    public class ExtraPickupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        // GET: ExtraPickups/Create
        public ActionResult ExtraPickUp(int? id)
        {
            ExtraPickup extraPickup = db.ExtraPickups.Find(id);

            return View();
        }

        // POST: ExtraPickups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExtraPickUp([Bind(Include = "Id,CustomerId,ExtraPickUp_start,ExtraPickUp_end")] ExtraPickup extraPickup, string value)
        {
            if (ModelState.IsValid)
            {
                var currentCustomer = User.Identity.GetUserId();
                extraPickup.CustomerId = currentCustomer; db.ExtraPickups.Add(extraPickup);
                db.SaveChanges();
                return RedirectToAction("Account", "Customers");
            }

            return View(extraPickup);
        }




        // GET: ExtraPickups
        //public ActionResult Index()
        //{
        //    var extraPickups = db.ExtraPickups.Include(e => e.Customers);
        //    return View(extraPickups.ToList());
        //}

        // GET: ExtraPickups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraPickup extraPickup = db.ExtraPickups.Find(id);
            if (extraPickup == null)
            {
                return HttpNotFound();
            }
            return View(extraPickup);
        }

        // GET: ExtraPickups/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId");
            return View();
        }

        // POST: ExtraPickups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,ExtraPickUp_start,ExtraPickUp_end,ExtraPickUpComleted,Fee")] ExtraPickup extraPickup)
        {
            if (ModelState.IsValid)
            {
              //  extraPickup.CustomerId = db.Customers.Select(c => c.Id).SingleOrDefault();
             //   extraPickup.Id = extraPickup.CustomerId;

                db.ExtraPickups.Add(extraPickup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId", extraPickup.CustomerId);
            return View(extraPickup);
        }

        // GET: ExtraPickups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraPickup extraPickup = db.ExtraPickups.Find(id);
            if (extraPickup == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId", extraPickup.CustomerId);
            return View(extraPickup);
        }

        // POST: ExtraPickups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,ExtraPickUp_start,ExtraPickUp_end,ExtraPickUpComleted,Fee")] ExtraPickup extraPickup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extraPickup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId", extraPickup.CustomerId);
            return View(extraPickup);
        }

        // GET: ExtraPickups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraPickup extraPickup = db.ExtraPickups.Find(id);
            if (extraPickup == null)
            {
                return HttpNotFound();
            }
            return View(extraPickup);
        }

        // POST: ExtraPickups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExtraPickup extraPickup = db.ExtraPickups.Find(id);
            db.ExtraPickups.Remove(extraPickup);
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
