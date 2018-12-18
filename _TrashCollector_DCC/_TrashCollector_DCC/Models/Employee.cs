using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _TrashCollector_DCC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public string State { get; set; }
        public string Zip { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}