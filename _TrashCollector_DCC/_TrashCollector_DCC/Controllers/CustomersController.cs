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
            var currentEmpId = User.Identity.GetUserId();
            
            Employee employee = db.Employees.Where(c => c.ApplicationUserId == currentEmpId).FirstOrDefault();


            List<Customer> customer = db.Customers.Where(c => c.ZipCode == employee.ZipCode).ToList();

            CustomerViewModel viewm = new CustomerViewModel();
            viewm.CustomersList = customer;
            //viewm.EmployeesList = employee;

            return View(viewm);
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
        public ActionResult Create( Customer customer)
        {
            var currentCustomer = User.Identity.GetUserId();
            customer.ApplicationUserId = currentCustomer;
            
                db.Customers.Add(customer);
                db.SaveChanges();
            

            //ViewBag.CustomerID = new SelectList(db.Customers, "Id", "FirstName", customer.Id);
            return RedirectToAction("CreatePickup", "CustomerInfoes");
        }

        // GET: Customers/Create
        


        // GET: Customers/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    var edditing = db.Customers.Where(e => e.Id == id).Select(e => e).SingleOrDefault();

        //             return View(edditing);
        //}


        public ActionResult Edit()
        {
            var currentuser = User.Identity.GetUserId();
            Customer customer = db.Customers.Where(s => s.ApplicationUserId == currentuser).SingleOrDefault();
            CustomerInfo info = db.CustomersInfo.Where(i => i.Id == customer.Id).SingleOrDefault();
            CustomerViewModel viewm = new CustomerViewModel();
            viewm.AllCustomers = customer;
            viewm.AllCustomersInfo = info;
                //ViewBag.customer.Id = new SelectList(db.Customers, "Id", "FirstName", customer.Id);
            return View(viewm);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            //var edditing = db.Customers.Where(e => e.Id == id).Include(e => e.ApplicationUser).SingleOrDefault();

            CustomerInfo CustInfo = db.CustomersInfo.Where(i => i.Id == id).SingleOrDefault();
            Customer Cust = db.Customers.Where(i => i.Id == id).SingleOrDefault();


            // Need to change the model to an INT
            Cust.FirstName = collection["AllCustomers.FirstName"];
            Cust.LastName = collection["AllCustomers.LastName"];
            Cust.Address = collection["AllCustomers.Address"];
            Cust.City = collection["AllCustomers.City"];
            Cust.State = collection["AllCustomers.State"];
            Cust.ZipCode = Int32.Parse(collection["AllCustomers.ZipCode"]);
            CustInfo.WeeklyPickup = collection["AllCustomersInfo.WeeklyPickup"];

            db.SaveChanges();
            return View();
            //return RedirectToAction("Index");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,ZipCode,CustomerID")] Customer customer)
        //{


        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(customer).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.customer.Id = new SelectList(db.Customers, "Id", "FirstName", customer.Id);
        //    return View(customer);
        //}

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
