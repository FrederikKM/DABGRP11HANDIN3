using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DABHandIN3_2v2.Models
{
    public class PrimaryAddress
    {
     
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }

       
        public Person Person { get; set; }
    }
}