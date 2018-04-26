using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public AddressName AddressName { get; set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; set; } = new List<PersonAddress>();
        public virtual ICollection<AddressType> AddressTypes { get; set; } = new List<AddressType>();

        //Foreign key
        public int CityId { get; set; }
        //Navigation property
        public virtual City City { get; set; }
    }
}