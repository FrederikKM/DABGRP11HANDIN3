using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB2_2RDBv2.Models;
using DAB2_2RDBv2.Repositories;

namespace DAB2_2RDBv2
{
    public class UnitOfWork : IDisposable
    {
        public DatabaseContext Context { get; set; }

        public IGenericRepository<Person> PersonRepository { get; set; }
        public IGenericRepository<PhoneNumber> PhoneRepository { get; set; }

        public IGenericRepository<AlternativeAddress> AltAddressesRepository { get; set; }

        public IGenericRepository<PrimaryAddress> PrimaryAddressRepository { get; set; }

        public UnitOfWork(DatabaseContext context)
        {
            Context = context;
            PersonRepository = new GenericRepository<Person>(Context);
            PhoneRepository = new GenericRepository<PhoneNumber>(Context);
            AltAddressesRepository = new GenericRepository<AlternativeAddress>(Context);
            PrimaryAddressRepository = new GenericRepository<PrimaryAddress>(Context);
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
