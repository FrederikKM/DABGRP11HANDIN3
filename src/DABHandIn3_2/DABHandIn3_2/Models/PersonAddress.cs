using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class PersonAddress
    {
        [Key]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        //Foreign key
        public int AddressId { get; set; }
        //Navigation Property
        public virtual Address Address { get; set; }
    }
}