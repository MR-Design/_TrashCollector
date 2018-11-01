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
    public class CustomerInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerInfoes
        public ActionResult Index()
        {
            return View(db.CustomersInfo.ToList());
        }

        // GET: CustomerInfoes/Details/5
        public ActionResult DetailsMoney()
        {

            var currentCustomer = User.Identity.GetUserId();
            var thiscustomer = db.Customers.Where(c => c.ApplicationUserId == currentCustomer).SingleOrDefault();
            var thisCustomerInfo = db.CustomersInfo.Where(m => m.CustomerInfoID == thiscustomer.Id).SingleOrDefault();
            //customerInfo.CustomerInfoID = thiscustomer.Id;
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //customerInfo= db.CustomersInfo.Where(c => c.CustomerInfoID == id).SingleOrDefault();
            //if (customerInfo == null)
            //{
            //    return HttpNotFound();
            //}
            return View(thisCustomerInfo);
        }

        // GET: CustomerInfoes/Create      
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Money,WeeklyPickup,SuspendPickupsStart,SuspendPickupsEnd,ExtraPickup")] CustomerInfo customerInfo)
        {
            var currentCustomer = User.Identity.GetUserId();
            var thiscustomer = db.Customers.Where(c => c.ApplicationUserId == currentCustomer).SingleOrDefault();

            customerInfo.CustomerInfoID = thiscustomer.Id;
            //var fk = db.CustomersInfo.Where(s => s.CustomerInfoID == customer.id).SingleOrDefault();
            db.CustomersInfo.Add(customerInfo);
            db.SaveChanges();
            if (ModelState.IsValid)
            {
                db.CustomersInfo.Add(customerInfo);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
            //    return View(customerInfo);
        }


        //CreateSusPickups

        public ActionResult CreateSusPickups()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSusPickups([Bind(Include = "Money,WeeklyPickup,SuspendPickupsStart,SuspendPickupsEnd,ExtraPickup")] CustomerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                db.CustomersInfo.Add(customerInfo);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
            //    return View(customerInfo);
        }


        // NewPickup
        public ActionResult NewPickup()
        {
            return View();
        }



        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewPickup([Bind(Include = "Money,WeeklyPickup,SuspendPickupsStart,SuspendPickupsEnd,ExtraPickup")] CustomerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                db.CustomersInfo.Add(customerInfo);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
            //    return View(customerInfo);
        }


        // GET: CustomerInfoes/Create      
        public ActionResult CreatePickup()
        {
            return View();
        }

        // POST: CustomerInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePickup([Bind(Include = "Money,WeeklyPickup,SuspendPickupsStart,SuspendPickupsEnd,ExtraPickup")] CustomerInfo customerInfo)
        {
            var currentCustomer = User.Identity.GetUserId();
            var thiscustomer = db.Customers.Where(c => c.ApplicationUserId == currentCustomer).SingleOrDefault();

            customerInfo.CustomerInfoID = thiscustomer.Id;
            //var fk = db.CustomersInfo.Where(s => s.CustomerInfoID == customer.id).SingleOrDefault();
            db.CustomersInfo.Add(customerInfo);
            db.SaveChanges();

            if (ModelState.IsValid)
            {

                db.CustomersInfo.Add(customerInfo);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
            //    return View(customerInfo);
        }

        // GET: CustomerInfoes/Edit/5
        public ActionResult Edit(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfo customerInfo = db.CustomersInfo.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            return View(customerInfo);
        }

        // POST: CustomerInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Money,WeeklyPickup,SuspendPickupsStart,SuspendPickupsEnd,ExtraPickup")] CustomerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerInfo);
        }

        // GET: CustomerInfoes/Delete/5
        public ActionResult Delete(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfo customerInfo = db.CustomersInfo.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            return View(customerInfo);
        }

        // POST: CustomerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(double id)
        {
            CustomerInfo customerInfo = db.CustomersInfo.Find(id);
            db.CustomersInfo.Remove(customerInfo);
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
