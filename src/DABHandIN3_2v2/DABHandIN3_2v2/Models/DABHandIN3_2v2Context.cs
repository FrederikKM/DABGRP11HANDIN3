using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DABHandIN3_2v2.Models
{
    public class DABHandIN3_2v2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DABHandIN3_2v2Context() : base("name=DABHandIN3_2v2Context")
        {
        }

        public System.Data.Entity.DbSet<DABHandIN3_2v2.Models.AlternativeAddress> AlternativeAddresses { get; set; }

        public System.Data.Entity.DbSet<DABHandIN3_2v2.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<DABHandIN3_2v2.Models.PrimaryAddress> PrimaryAddresses { get; set; }

        public System.Data.Entity.DbSet<DABHandIN3_2v2.Models.PhoneNumber> PhoneNumbers { get; set; }
    }
}
