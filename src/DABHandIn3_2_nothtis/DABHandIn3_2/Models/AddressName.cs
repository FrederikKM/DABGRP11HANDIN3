using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class AddressName
    {
        [Key]
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
    }
}