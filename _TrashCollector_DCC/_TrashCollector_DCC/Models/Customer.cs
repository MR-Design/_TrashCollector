using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _TrashCollector_DCC.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        //[Display(Name = "First Name")]
        public string FirstName { get; set; }

        //[Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Address Line 1")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Enter 5 Digit Please")]
        public string ZipCode { get; set; }
      
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
    }
}