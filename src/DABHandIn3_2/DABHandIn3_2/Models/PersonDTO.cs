using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class PersonDTO
    {
        public PersonDTO(Person person)
        {

        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}

