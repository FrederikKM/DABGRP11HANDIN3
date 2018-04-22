using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB2_2RDBv2.Models
{
    public class PrimaryAddress
    {
        [Key]
        public int PrimaryAddressId { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }

        public virtual Person Person { get; set; }
    }
}
