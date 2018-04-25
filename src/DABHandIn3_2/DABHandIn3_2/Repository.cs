using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DABHandIn3_2.Models;

namespace DABHandIn3_2
{
    public class Repository
    {
        public interface IGenericRepository<TEntity> where TEntity : class
        {

            IEnumerable<TEntity> GetAll();
            TEntity GetById(int Id);
            void Add(TEntity entity);
            void Delete(TEntity entity);

        }

        public class GenericRepository<TEntity> :
            IGenericRepository<TEntity> where TEntity : class
        {

            private DABHandIn3_2Context _context;

            public GenericRepository(DABHandIn3_2Context context)
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