using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DABHandIN3_2v2.Models
{
    public class PhoneNumber
    {
        
        public int Id { get; set; }
        public string Number { get; set; }
        public string Usage { get; set; }

        public string PhoneCompany { get; set; }

        public int PeopleId { get; set; }
        public Person Person { get; set; }
    }
}