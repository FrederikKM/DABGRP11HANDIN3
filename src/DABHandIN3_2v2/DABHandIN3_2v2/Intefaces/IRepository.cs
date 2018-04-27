using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABHandIN3_2v2.Intefaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id);
        void Add(TEntity entity);
        void Delete(TEntity entity);

    }
}
