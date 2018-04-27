namespace DABHandIn3_2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DABHandIn3_2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DABHandIn3_2.Models.DABHandIn3_2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DABHandIn3_2.Models.DABHandIn3_2Context context)
        {
            context.People.AddOrUpdate(x => x.Id,
                new Person() {Id = 1, FirstName = "Stefanie", MiddleName = "Ruaya", LastName = "Nielson"},
                new Person() {Id = 2, FirstName = "Poul", LastName = "Jensen"},
                new Person() {Id = 3, FirstName = "Frederik", MiddleName = "Kastrup", LastName = "Mortensen"}
            );

            context.PhoneNumbers.AddOrUpdate(x => x.Id,
                new PhoneNumber() {Id = 1, Number = "11111111", Usage = "Private", PhoneCompany = "TDC"},
                new PhoneNumber() {Id = 2, Number = "22222222", Usage = "Work", PhoneCompany = "TDC"},
                new PhoneNumber() {Id = 3, Number = "33333333", Usage = "Private", PhoneCompany = "Oister"}
            );
            context.PrimaryAddresses.AddOrUpdate(x => x.Id,
                new PrimaryAddress()
                {
                    Id = 1,
                    StreetName = "Aarhusvej",
                    HouseNumber = "4",
                    City = "Aarhus",
                    ZipCode = "8000"
                },
                new PrimaryAddress()
                {
                    Id = 2,
                    StreetName = "Tilstvej",
                    HouseNumber = "4",
                    City = "Tilst",
                    ZipCode = "8381"
                },
                new PrimaryAddress()
                {
                    Id = 3,
                    StreetName = "Odensevej",
                    HouseNumber = "4",
                    City = "Odense",
                    ZipCode = "5000"
                }
            );

            context.AlternativeAddresses.AddOrUpdate(x => x.Id,
                new AlternativeAddress()
                {
                    Id = 1,
                    StreetName = "Kastrupvej",
                    HouseNumber = "4",
                    City = "Kastrup",
                    ZipCode = "4092"
                },
                new AlternativeAddress()
                {
                    Id = 2,
                    StreetName = "Solsikkevænget",
                    HouseNumber = "4",
                    City = "Odense",
                    ZipCode = "5000"
                },
                new AlternativeAddress()
                {
                    Id = 3,
                    StreetName = "Lykkevej",
                    HouseNumber = "4",
                    City = "København",
                    ZipCode = "2000"
                }
            );

        }
    }
}
