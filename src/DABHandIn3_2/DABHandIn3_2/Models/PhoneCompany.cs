using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class PhoneCompany
    {
        [Required]
        public string CompanyName { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
    }
}