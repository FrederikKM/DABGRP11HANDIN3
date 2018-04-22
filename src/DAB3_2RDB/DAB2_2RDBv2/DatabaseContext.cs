using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB2_2RDBv2.Models;

namespace DAB2_2RDBv2
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<AlternativeAddress> AltAddress { get; set; }
        public DbSet<PhoneNumber> PhoneNumber { get; set; }
        public DbSet<PrimaryAddress> PrimaryAdress { get; set; }

        public DatabaseContext(): base("name=HandIn2-2"){}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(p =>p.PhoneNumbers)
                .WithRequired()
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
