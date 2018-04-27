using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class PhoneNumber
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Usage { get; set; }

        public string PhoneCompany { get; set; }

        //Foreign key
        public int PeopleId { get; set; }
        //Navigation property
        public Person Person { get; set; }
    }
}