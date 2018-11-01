using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _TrashCollector_DCC.Models
{
    public class CustomerInfo
    {
        [Key]
        public int Id { get; set; }

        public double Money { get; set; }

       

        [ForeignKey("Customer")]
        public int CustomerInfoID { get; set; }
        public Customer Customer { get; set; }


        [Display(Name = "Weekly Pickup")]
        public string WeeklyPickup  { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SuspendPickupsStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SuspendPickupsEnd { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExtraPickup { get; set; }
     
    }
}