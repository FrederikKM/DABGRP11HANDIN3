using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABHandIn3_2.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id);
        void Add(TEntity entity);
        void Delete(TEntity entity);

    }
}
