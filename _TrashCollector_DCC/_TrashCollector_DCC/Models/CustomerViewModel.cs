using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _TrashCollector_DCC.Models
{
    public class CustomerViewModel
    {
        public Customer AllCustomers  { get; set; }
        public CustomerInfo AllCustomersInfo  { get; set; }

        public Employee AllEployees { get; set; }
        public List<Employee> EmployeesList { get; set; }
        public List<Customer> CustomersList { get; set; }
        public List<CustomerInfo> CustomersInfoList { get; set; }


    }
}