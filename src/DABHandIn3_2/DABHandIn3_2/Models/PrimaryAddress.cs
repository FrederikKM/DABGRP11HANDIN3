using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class PrimaryAddress
    {
        [Key]
        public int Id { get; set; }
        public AddressName AddressName { get; set; }
        //Foreign key
        public int CityId { get; set; }
        //Naviagtion property
        public City City { get; set; }
    }
}