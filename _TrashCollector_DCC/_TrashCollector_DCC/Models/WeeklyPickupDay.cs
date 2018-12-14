using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _TrashCollector_DCC.Models
{
    public class WeeklyPickupDay
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }

        [Display(Name = "Select your weekly pickup day")]
        public string WeeklyPickUpDay { get; set; }
        public bool WeeklyPickUpDayCompleted { get; set; }
        public double? Balance { get; set; }
    }
}