using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _TrashCollector_DCC.Models
{
    public class ExtraPickup
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Specify your Starting pickup Date")]
        public DateTime? ExtraPickUp_start { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Specify your Ending pickup Date")]
        public DateTime? ExtraPickUp_end { get; set; }

        public bool ExtraPickUpComleted { get; set; }
        public double? Fee { get; set; }
    }
}