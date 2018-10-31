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
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.ToList() ;
            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "Id", "FirstName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Address,ZipCode")] Customer customer)
        {
            var currentCustomer = User.Identity.GetUserId();
            customer.ApplicationUserId = currentCustomer;
            
                db.Customers.Add(customer);
                db.SaveChanges();
            

            ViewBag.CustomerID = new SelectList(db.Customers, "Id", "FirstName", customer.Id);
            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    var edditing = db.Customers.Where(e => e.Id == id).Select(e => e).SingleOrDefault();

        //             return View(edditing);
        //}

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{

        //    var edditing = db.Customers.Where(e => e.Id == id).Select(e => e).SingleOrDefault();


        //        // Need to change the model to an INT
        //    edditing.FirstName = collection["FirstName"];
        //    edditing.LastName = collection["LastName"];
        //    edditing.Address = collection["Address"];
        //    edditing.ZipCode = Int32.Parse(collection["ZipCode"]); 
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult Edit()
        {
            var currentuser = User.Identity.GetUserId();
            Customer customer = db.Customers.Where(s => s.ApplicationUserId == currentuser).SingleOrDefault();
            var CusomerInfoView = new CustomerViewModel();

            //ViewBag.customer.Id = new SelectList(db.Customers, "Id", "FirstName", customer.Id);
            return View(CusomerInfoView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,ZipCode,CustomerID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer.Id = new SelectList(db.Customers, "Id", "FirstName", customer.Id);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
