using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class PersonAddressType
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int AddressTypeId { get; set; }
        public AddressType AddressType { get; set; }
    }
}