using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DABHandIn3_2.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Relation { get; set; }

        public string Email { get; set; }

       // [Required]
        //public virtual PrimaryAddress PrimaryAddress { get; set; }

        //public virtual List<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
        //public virtual List<AlternativeAddress> AlternativeAddresses { get; set; } = new List<AlternativeAddress>();
    }
}