using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DAB2_2RDBv2.Repositories
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

        private DatabaseContext _context;

        public GenericRepository(DatabaseContext context)
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
