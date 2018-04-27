using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class AddressType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual Address Address { get; set; }
    }
}