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
    public class SuspendPickUpsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SuspendPickUps
        public ActionResult Index()
        {
            var suspendPickUps = db.SuspendPickUps.Include(s => s.Customers);
            return View(suspendPickUps.ToList());
        }

        // GET: SuspendPickUps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspendPickUp suspendPickUp = db.SuspendPickUps.Find(id);
            if (suspendPickUp == null)
            {
                return HttpNotFound();
            }
            return View(suspendPickUp);
        }

        // GET: SuspendPickUps/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName");
            return View();
        }

        // POST: SuspendPickUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,IsSuspended,StartDate,EndDate")] SuspendPickUp suspendPickUp)
        {
            if (ModelState.IsValid)
            {
                db.SuspendPickUps.Add(suspendPickUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", suspendPickUp.CustomerId);
            return View(suspendPickUp);
        }

        // GET: SuspendPickUps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspendPickUp suspendPickUp = db.SuspendPickUps.Find(id);
            if (suspendPickUp == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", suspendPickUp.CustomerId);
            return View(suspendPickUp);
        }

        // POST: SuspendPickUps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,IsSuspended,StartDate,EndDate")] SuspendPickUp suspendPickUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suspendPickUp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", suspendPickUp.CustomerId);
            return View(suspendPickUp);
        }

        // GET: SuspendPickUps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspendPickUp suspendPickUp = db.SuspendPickUps.Find(id);
            if (suspendPickUp == null)
            {
                return HttpNotFound();
            }
            return View(suspendPickUp);
        }

        // POST: SuspendPickUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuspendPickUp suspendPickUp = db.SuspendPickUps.Find(id);
            db.SuspendPickUps.Remove(suspendPickUp);
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
