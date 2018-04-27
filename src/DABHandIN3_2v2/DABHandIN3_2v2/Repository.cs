using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DABHandIN3_2v2.Intefaces;
using DABHandIN3_2v2.Models;

namespace DABHandIN3_2v2
{
    public class Repository<TEntity> :
        IRepository<TEntity> where TEntity : class
    {

        private readonly DABHandIN3_2v2Context _context;

        public Repository(DABHandIN3_2v2Context context)
        {
            _context = context;
        }


        public virtual IEnumerable<TEntity> GetAll()
        {

            IEnumerable<TEntity> query = _context.Set<TEntity>().ToList();
            return query;
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

    }
}