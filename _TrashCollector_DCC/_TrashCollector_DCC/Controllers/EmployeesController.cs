﻿using System;
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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers/Edit/5
        public ActionResult Charge(int? id)
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
        public ActionResult Charge([Bind(Include = "Id,FirstName,LastName,Street,City,State,Zip,Lat,Lng,WeeklyPickUpDay,WeeklyPickUpDayCompleted,Balance,StartDate,EndDate,IsSuspended,UserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
             
                if (customer.WeeklyPickUpDayCompleted == true && customer.IsSuspended == false)
                {
                    customer.Balance += 20;
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                }
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Employees");
            }
            return View(customer);
        }
        // GET: Employees
        public ActionResult Index(EmployeeViewModel view)
        {
          
            view = new EmployeeViewModel()
            {
                customer = new Customer(),
                customers = new List<Customer>(),
                employee = new Employee(),
        
            };
            var currentEmployee = User.Identity.GetUserId();
            var employeeZip = db.Employees.Where(e=>e.UserId == currentEmployee).Select(x => x.Zip).FirstOrDefault();
            var Today = DateTime.Now.DayOfWeek.ToString();

            view.customers = db.Customers.Where(x => x.Zip == employeeZip && x.WeeklyPickUpDay == Today).ToList();
            if(view.customer.ExtraPick == "Extra Pickup ")
            {
                var thisDay = view.customer.ExtraPickUp.Value.DayOfWeek.ToString();
                view.customers = db.Customers.Where(x => x.Zip == employeeZip && x.WeeklyPickUpDay == thisDay).ToList();
            }

            return View(view);
        }

        [HttpPost]
        public ActionResult Index(string search, EmployeeViewModel view)
        {

            view = new EmployeeViewModel()
            {
                customer = new Customer(),
                customers = new List<Customer>(),
                employee = new Employee()

            };

            if (!String.IsNullOrEmpty(search))
            {
                var currentEmployee = User.Identity.GetUserId();
                var employeeZip = db.Employees.Where(e => e.UserId == currentEmployee).Select(x => x.Zip).FirstOrDefault();
                view.customers = db.Customers.Where(x => x.Zip == employeeZip).ToList();
                view.customers = db.Customers.Where(s => s.WeeklyPickUpDay.Contains(search) && s.Zip== employeeZip).ToList(); 
            }

           

            return View(view);
        }

        // GET: Employees
        public ActionResult DefaultIndex()
        {

            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Street,City,State,Zip,Lat,Lng")] Employee employee)
        {
            var currentCustomer = User.Identity.GetUserId();
            employee.UserId = currentCustomer;
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index", "Employees");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Street,City,State,Zip,Lat,Lng")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Employees");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index", "Employees");
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
//Employees Index
//  if (view.customer.ExtraPick == 0)
//            {
//                view.customers = db.Customers.Where(x => x.Zip == employeeZip && x.WeeklyPickUpDay == Today).ToList();

//            }else
//            {
//                var thisDay = view.customer.ExtraPickUp.Value.DayOfWeek.ToString();
//view.customers = db.Customers.Where(x => x.Zip == employeeZip && x.WeeklyPickUpDay == thisDay).ToList();

//            }