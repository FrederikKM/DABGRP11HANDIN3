using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DABHandIn3_2.Models;
using DABHandIn3_2.Interfaces;

namespace DABHandIn3_2
{
    public class UnitOfWork : IDisposable
    {
        public DABHandIn3_2Context Context { get; set; }

        public Repository<Person> PersonRepository { get; set; }
        public Repository<PhoneNumber> PhoneRepository { get; set; }

        public Repository<AlternativeAddress> AltAddressesRepository { get; set; }

        public Repository<PrimaryAddress> PrimaryAddressRepository { get; set; }

        public UnitOfWork(DABHandIn3_2Context context)
        {
            Context = context;
            PersonRepository = new Repository<Person>(Context);
            PhoneRepository = new Repository<PhoneNumber>(Context);
            AltAddressesRepository = new Repository<AlternativeAddress>(Context);
            PrimaryAddressRepository = new Repository<PrimaryAddress>(Context);
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Save()
        {

            try
            {

                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}