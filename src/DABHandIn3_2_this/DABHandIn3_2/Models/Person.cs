﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DABHandIn3_2.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Relation { get; set; }

        public string Email { get; set; }

        [Required]
        public PrimaryAddress PrimaryAddress { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; } = new List<PersonAddress>();
    }
}