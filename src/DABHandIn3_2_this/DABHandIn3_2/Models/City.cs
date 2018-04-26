using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class City
    {
        public string Name { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    }
}