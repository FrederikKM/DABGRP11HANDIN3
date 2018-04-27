using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class PersonAddressType
    {
        [Key]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        //Foreign key
        public int AddressTypeId { get; set; }
        //Naviagtion property
        public AddressType AddressType { get; set; }
    }
}