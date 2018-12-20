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

        // GET: Customers/Delete/5
        public ActionResult Pay(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pay(int id)
        {
            Customer customer = db.Customers.Find(id);
            customer.Balance = 0;

            db.Entry(customer).State = EntityState.Modified; db.SaveChanges();
            return RedirectToAction("Account", "Customers");
        }

        // GET: Customers/Delete/5
        public ActionResult ActivateAccount(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActivateAccount(int id)
        {
            Customer customer = db.Customers.Find(id);
                  customer.IsSuspended = false;

            db.Entry(customer).State = EntityState.Modified; db.SaveChanges();
            return RedirectToAction("Account", "Customers");
        }

      
        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
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
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Street,City,State,Zip,WeeklyPickUpDay,UserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var currentCustomer = User.Identity.GetUserId();
                customer.UserId = currentCustomer;
                customer.Balance = 0.00;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Account", "Customers");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Street,City,State,Zip,WeeklyPickUpDay,WeeklyPickUpDayCompleted,Balance,StartDate,EndDate,IsSuspended,UserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var currentCustomer = User.Identity.GetUserId();
                customer.UserId = currentCustomer;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Account", "Customers");
            }
            return View(customer);
        }


        // GET: Customers/Edit/5
        public ActionResult ExtraPickUp(int? id)
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

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExtraPickUp([Bind(Include = "Id,FirstName,LastName,Street,City,State,Zip,Lat,Lng,WeeklyPickUpDay,WeeklyPickUpDayCompleted,Balance,StartDate,EndDate,IsSuspended,UserId,ExtraPickUp,ExtraPickUpComleted,Fee")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var currentCustomer = User.Identity.GetUserId();
                customer.UserId = currentCustomer;
                customer.ExtraPick = "Extra Pickup ";
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Account", "Customers");
            }
            return View(customer);
        }


        // GET: Customers/Edit/5
        public ActionResult EditWeeklyPickup(int? id)
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

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditWeeklyPickup([Bind(Include = "Id,FirstName,LastName,Street,City,State,Zip,Lat,Lng,WeeklyPickUpDay,WeeklyPickUpDayCompleted,Balance,StartDate,EndDate,IsSuspended,UserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var currentCustomer = User.Identity.GetUserId();
                customer.UserId = currentCustomer;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Account", "Customers");
            }
            return View();
        }

        // GET: Customers/Edit/5
        public ActionResult SuspendAcount(int? id)
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

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuspendAcount([Bind(Include = "Id,FirstName,LastName,Street,City,State,Zip,Lat,Lng,WeeklyPickUpDay,WeeklyPickUpDayCompleted,Balance,StartDate,EndDate,IsSuspended,UserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var currentCustomer = User.Identity.GetUserId();
                customer.UserId = currentCustomer;
                customer.IsSuspended = true;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Account", "Customers");
            }
            return View();
        }
        // GET: Account/Details/5
        public ActionResult Account(CustomerAccountViewModel view)
        {
             view = new CustomerAccountViewModel()
            {
                customer = new Customer(),
                //extraPickups = new List<ExtraPickup>()

        };
            var currentUser = User.Identity.GetUserId();
            //view.extraPickups = db.ExtraPickups.Where(e => e.CustomerId == currentUser).ToList();


            Customer customer = db.Customers.Where(s => s.UserId == currentUser).SingleOrDefault();
            view.customer = customer;
            var customers =  db.Customers
                .Include(r => r.ApplicationUser)
                .FirstOrDefault(m => m.UserId == currentUser);


            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(view);
        }



        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        

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
            return RedirectToAction("Account", "Customers");
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
