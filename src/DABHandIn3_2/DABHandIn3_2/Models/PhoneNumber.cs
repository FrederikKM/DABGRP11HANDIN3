using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class PhoneNumber
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Usage { get; set; }

        public string PhoneCompany { get; set; }

        public virtual Person Person { get; set; }


    }
}