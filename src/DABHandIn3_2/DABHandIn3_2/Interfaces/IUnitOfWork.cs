﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DABHandIn3_2.Models;

namespace DABHandIn3_2.Interfaces
{
    interface IUnitOfWork
    {

        IRepository<Person> PersonRepository { get; set; }
        IRepository<PhoneNumber> PhoneRepository { get; set; }

        IRepository<AlternativeAddress> AltAddressesRepository { get; set; }

        IRepository<PrimaryAddress> PrimaryAddressRepository { get; set; }

        Task SaveAsync();
        void Save();
        void Dispose();

    }
}
