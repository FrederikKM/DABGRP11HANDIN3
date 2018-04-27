using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DABHandIN3_2v2.Models;

namespace DABHandIN3_2v2.Intefaces
{
    public interface IUnitOfWork
    {
        IRepository<Person> PersonRepository { get; set; }
        IRepository<PhoneNumber> PhoneRepository { get; set; }

        IRepository<AlternativeAddress> AltAddressRepository { get; set; }

        IRepository<PrimaryAddress> PrimaryAddressRepository { get; set; }
        Task SaveAsync();
        void Save();
        void Dispose();

    }
}
