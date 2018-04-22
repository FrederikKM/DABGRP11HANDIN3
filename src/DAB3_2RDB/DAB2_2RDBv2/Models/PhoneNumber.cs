using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB2_2RDBv2.Models
{
    public class PhoneNumber
    {
        [Key]
        public int PhoneNumberId { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }

        public string PhoneCompany { get; set; }

        public virtual Person Person { get; set; }
    }
}
