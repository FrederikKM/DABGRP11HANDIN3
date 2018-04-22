using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DAB2_2RDBv2.Models;
using DAB2_2RDBv2.Repositories;

namespace DAB2_2RDBv2
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DatabaseContext();
            using (var uow = new UnitOfWork(db))
            {
                var person = new Person
                {
                    FirstName = "Stefanie",
                    MiddleName = "Ruaya",
                    LastName = "Nielson",
                    Email = "GoPoke@gmail.com",
                    Relation = "Me",
                    PhoneNumbers = new List<PhoneNumber>()
                    {
                        new PhoneNumber
                        {
                            Number = "00000000",
                            Type = "Private",
                            PhoneCompany = "TDC"
                        },
                        new PhoneNumber
                        {
                            Number = "12345678",
                            Type = "Work",
                            PhoneCompany = "TDC"
                        }
                    },
                    

                    AlternativeAddresses = new List<AlternativeAddress>()
                    {
                        new AlternativeAddress
                        {
                            StreetName = "TilstVej",
                            HouseNumber = "4",
                            City = "Tilst",
                            ZipCode = "8381",
                        },

                        new AlternativeAddress
                        {
                            StreetName = "TilstVej",
                            HouseNumber = "5",
                            City = "Tilst",
                            ZipCode = "8381",
                        }
                    },
                    PrimaryAddress = new PrimaryAddress
                    {
                        StreetName = "Aarhusvej",
                        HouseNumber = "4",
                        City = "Aarhus",
                        ZipCode = "8000",
                    }
                };


                //Create person
                uow.PersonRepository.Add(person);

                uow.Save();
                Console.WriteLine("Person: " + person.FirstName + " " + person.LastName + " Created\n\n");

                //Read data and print to console

                person = uow.PersonRepository.GetById(1);
                Console.WriteLine("Reading data for person with personId: " + person.PersonId);
                PrintHelperFunction(person);


                //Update
                var update = uow.PersonRepository.GetById(1);
                Console.WriteLine("\n\nUpdating person with personId: " + update.PersonId);
                update.FirstName = "Frederik";
                var updatedAddress = uow.PrimaryAddressRepository.GetById(1);
                updatedAddress.StreetName = "Tilstvej";

                uow.Save();
                PrintHelperFunction(update);

                //Delete
                // uow.PersonRepository.Delete(person);
                // uow.Save();
            }
        }

        private static void PrintHelperFunction(Person person)
        {
            Console.WriteLine("Person: " + person.FirstName + " " + person.MiddleName + " " + person.LastName);
            Console.WriteLine("Relation: " + person.Relation);
            Console.WriteLine("Email: " + person.Email);
            var primaryAddress = person.PrimaryAddress;
            Console.WriteLine("Primary Address: " + primaryAddress.StreetName + " " + primaryAddress.HouseNumber + " "
                              + primaryAddress.ZipCode + " " + primaryAddress.City);

            foreach (var phoneNumber in person.PhoneNumbers)
            {
                Console.WriteLine("Phonenumbers: " + phoneNumber.Number + "Type: " + phoneNumber.Type + "Company: " + phoneNumber.PhoneCompany);
            }

            foreach (var alternativeAddress in person.AlternativeAddresses)
            {
                Console.WriteLine("Alternative address: " + alternativeAddress.StreetName + " " +
                                  alternativeAddress.HouseNumber + " "
                                  + alternativeAddress.ZipCode + " " + alternativeAddress.City);
            }
        }
    }
}