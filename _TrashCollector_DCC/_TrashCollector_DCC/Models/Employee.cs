using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _TrashCollector_DCC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        // Here where I link the regestration Table with the Customer Table
        [ForeignKey("Employee Info")]
        [Display(Name = " Employee Info")]
        public int EmployeeID { get; set; }
        public Employee Employees { get; set; }

        //end here
        public IEnumerable<Employee> employee { get; set; }
    }
}
