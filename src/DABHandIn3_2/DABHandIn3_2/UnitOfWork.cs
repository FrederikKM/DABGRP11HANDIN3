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
        private IRepository<Person> _personRepository { get; set; }
        private IRepository<PhoneNumber> _phoneRepository { get; set; }

        private IRepository<AlternativeAddress> _altAddressRepository { get; set; }

        private IRepository<PrimaryAddress> _primaryAddressRepository { get; set; }

        public UnitOfWork(DABHandIn3_2Context context)
        {
            Context = context;
            
        }

        public IRepository<Person> PersonRepository
        {
            get => _personRepository = _personRepository ?? new Repository<Person>(Context);
            set => _personRepository = value;
        }

        public IRepository<PhoneNumber> PhoneRepository
        {
            get => _phoneRepository = _phoneRepository ?? new Repository<PhoneNumber>(Context);
            set => _phoneRepository = value;
        }

        public IRepository<AlternativeAddress> AltAddressRepostiory
        {
            get => _altAddressRepository = _altAddressRepository ?? new Repository<AlternativeAddress>(Context);
            set => _altAddressRepository = value;
        }

        public IRepository<PrimaryAddress> PrimaryAddressesRepostiory
        {
            get => _primaryAddressRepository = _primaryAddressRepository ?? new Repository<PrimaryAddress>(Context);
            set => _primaryAddressRepository = value;
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