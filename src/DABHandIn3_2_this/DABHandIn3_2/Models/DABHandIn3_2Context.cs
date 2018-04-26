using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DABHandIn3_2.Models
{
    public class DABHandIn3_2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DABHandIn3_2Context() : base("name=DABHandIn3_2Context")
        {
        }

        public System.Data.Entity.DbSet<DABHandIn3_2.Models.AlternativeAddress> AlternativeAddresses { get; set; }

        public System.Data.Entity.DbSet<DABHandIn3_2.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<DABHandIn3_2.Models.PrimaryAddress> PrimaryAddresses { get; set; }

        public System.Data.Entity.DbSet<DABHandIn3_2.Models.PhoneNumber> PhoneNumbers { get; set; }
    }
}
