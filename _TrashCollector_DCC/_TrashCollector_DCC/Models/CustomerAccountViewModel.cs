using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _TrashCollector_DCC.Models
{
    public class CustomerAccountViewModel
    {
        public Customer cutomer { get; set; }
        public List<Customer> customers { get; set; }

        public WeeklyPickupDay weeklyPickupDay { get; set; }
        public List<WeeklyPickupDay> weeklyPickupDays { get; set; }

        public ExtraPickup extraPickup { get; set; }
        public List<ExtraPickup> extraPickups { get; set; }

        public SuspendPickUp suspendPickUp { get; set; }
        public List<SuspendPickUp> suspendPickUps { get; set; }




    }
}