using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Usage { get; set; }

        public string PhoneCompany { get; set; }

        //Foreign key
        public int PersonId { get; set; }
        //Navigation property
        public Person Person { get; set; }
    }
}