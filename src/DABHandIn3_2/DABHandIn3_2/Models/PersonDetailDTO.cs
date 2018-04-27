using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class PersonDetailDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Relation { get; set; }

        public string Email { get; set; }
    }
}