using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _TrashCollector_DCC.Models
{
    public class EmployeeViewModel
    {
        public Customer customer { get; set; }
        public List<Customer> customers { get; set; }

        public Employee employee { get; set; }
        public List<Employee> employees { get; set; }

        public ExtraPickup extraPickup { get; set; }
        public List<ExtraPickup> extraPickups { get; set; }
    }
}