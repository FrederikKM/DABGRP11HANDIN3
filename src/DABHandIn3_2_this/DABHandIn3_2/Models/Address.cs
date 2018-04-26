using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class Address
    {
        public class Addres
        {
            public AddressName AddressName { get; set; }

            public virtual ICollection<PersonAddress> PersonAddresses { get; set; } = new List<PersonAddress>();
            public virtual ICollection<AddressType> AddressTypes { get; set; } = new List<AddressType>();

            public int CityId { get; set; }
            public virtual City City { get; set; }
        }
    }
}