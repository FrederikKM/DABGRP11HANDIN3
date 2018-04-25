using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class AlternativeAddress
    {
        
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }

        //Foreign key
        public int PeopleId { get; set; }
        //Navigation property
        public Person Person { get; set; }
    }
}