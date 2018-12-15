using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _TrashCollector_DCC.Models
{
    public class CustomerAccountViewModel
    {
        public Customer customer { get; set; }
        public List<Customer> customers { get; set; }

        public ExtraPickup extraPickup { get; set; }
        public List<ExtraPickup> extraPickups { get; set; }

    }
}