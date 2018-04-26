using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class PrimaryAddress
    {
        public AddressName AddressName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}