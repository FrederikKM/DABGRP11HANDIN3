using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class AddressType
    {
        public string Type { get; set; }
        public virtual Address Address { get; set; }
    }
}