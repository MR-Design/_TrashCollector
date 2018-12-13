using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _TrashCollector_DCC.Models
{
    public class Customer
    {
        [Key]

        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Select your weekly pickup day")]
        public string WeeklyPickUpDay { get; set; }
        public bool WeeklyPickUpDayCompleted { get; set; }
        public double? Balance { get; set; }

        //Request Extra Pickup by Date
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Specify your Extra pickup Date")]
        public DateTime ExtraPickUp { get; set; }
        public bool ExtraPickUpComleted { get; set; }
        public double? Fee { get; set; }


        //Suspend Pickups by starting and Ending Date
        public bool IsSuspended { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }


        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }


        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }


    }
}