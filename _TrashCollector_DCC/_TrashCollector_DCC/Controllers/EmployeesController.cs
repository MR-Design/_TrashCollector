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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            
            var currentEmpId = User.Identity.GetUserId();

            Employee employee = db.Employees.Where(c => c.ApplicationUserId == currentEmpId).FirstOrDefault();
            CustomerViewModel viewm = new CustomerViewModel();
              
            List<Customer> customer = db.Customers.Where(c => c.ZipCode == employee.ZipCode).ToList();
            viewm.CustomersList = customer;
            // My Logic For Today Pick Up ... Need a  Nested Forloop maybe
            string today = DateTime.Today.DayOfWeek.ToString();
            List<CustomerInfo> custInfo = db.CustomersInfo.Where(c => c.WeeklyPickup == today).Include(c => c.Customer).ToList();
            List<CustomerInfo> onlyInZip = custInfo.Where(c => c.Customer.ZipCode == employee.ZipCode).ToList();
            viewm.CustomersInfoList = onlyInZip;

          
            return View(viewm);

        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {

            var currentEmpId = User.Identity.GetUserId();

            Employee employee = db.Employees.Where(c => c.ApplicationUserId == currentEmpId).FirstOrDefault();
            CustomerViewModel viewm = new CustomerViewModel();

            List<Customer> customer = db.Customers.Where(c => c.ZipCode == employee.ZipCode).ToList();
            viewm.CustomersList = customer;
            string today = DateTime.Today.DayOfWeek.ToString();
            List<CustomerInfo> custInfo = db.CustomersInfo.Where(c => c.WeeklyPickup == today).Include(c => c.Customer).ToList();
            

            //My Logic for the search..
            // I need To check How can I pull Input with a differnt way
            if (!String.IsNullOrEmpty(searchString))
            {

                custInfo = db.CustomersInfo.Where(s => s.WeeklyPickup == searchString).ToList();
                viewm.CustomersList = customer;
                db.SaveChanges();
            }
            return View(viewm);

        }
        //public ActionResult Today(List<CustomerInfo> cst)
        //{
        //    string today = DateTime.Today.DayOfWeek.ToString();
        //   // var cust = db.CustomersInfo.Where(c=>c.Id ==)
        //     db.Customers.Where(c => c.ApplicationUserId == cst.).FirstOrDefault();

        //    CustomerViewModel viewm = new CustomerViewModel();

        //    // My Logic For Today Pick Up ... Need a  Nested Forloop maybe


        //       // viewm.CustomersList = customer;
        //        db.SaveChanges();

        //    return View(viewm);

        //}


        public ActionResult Search(string sortOrder, string searchString)
        {
         
            CustomerViewModel viewm = new CustomerViewModel();
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Monday" : "";


            //List<Customer> customer = db.Customers.Select(c => c).ToList();
            //viewm.CustomersList = customer;

          

            List<CustomerInfo> custInfo = db.CustomersInfo.ToList();


            if (!String.IsNullOrEmpty(searchString)) {

                custInfo = db.CustomersInfo.Where(s => s.WeeklyPickup == searchString).ToList();
            }
            viewm.CustomersInfoList = custInfo;
            //var CustomersInEmployee = db.Employees.Include(c => c.ApplicationUsers);
            //return View(CustomersInEmployee.ToList());
            return View(viewm);
        }

        //public ActionResult Index(Customer customer)
        //{
        //    var employees = db.Customers.ToList();
        //    RedirectToAction("Index");
        //    return View(customer);
        //}

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Where(s => s.Id == id).SingleOrDefault();
            CustomerViewModel viewm = new CustomerViewModel();
            viewm.AllCustomers = customer;           
            return View(viewm);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create( Employee employee)
        {
            
            if (ModelState.IsValid)
            {
                var currentCustomer = User.Identity.GetUserId();
                employee.ApplicationUserId = currentCustomer;

                
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", employee.Id);
            return RedirectToAction("Index");
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
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", employee.Id);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmployeeID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "Id", "FirstName", employee.Id);
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
