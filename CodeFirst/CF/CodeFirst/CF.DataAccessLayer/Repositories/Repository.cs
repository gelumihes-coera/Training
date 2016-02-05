using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CF.DataAccessLayer;

namespace SOLIDapp.DataLayer.Repositories
{
    public class Repository
    {
        protected SchoolDbContext Context;
        
        public Repository()
        {
            Context = new SchoolDbContext();
        }

        public virtual void Add<T>(T entity) where T : class
        {
            Context.Set<T>().Add(entity);
            SaveContext();
        } 

        public virtual void Update<T>(T entity, int id) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existing = Context.Set<T>().Find(id);
            if (existing == null) return;
            Context.Entry(existing).CurrentValues.SetValues(entity);
            SaveContext();
        }

        public virtual void Delete<T>(object id) where T : class
        {

            T entity = Context.Set<T>().Find(id);
            if (entity != null)
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                {
                    Context.Set<T>().Attach(entity);
                }
                Context.Set<T>().Remove(entity);
            }
            SaveContext();
        }

        public T GetById<T>(params object[] keyValues) where T : class
        {
            return Context.Set<T>().Find(keyValues);
        }

        public virtual IQueryable<T> GetEntities<T>() where T : class
        {
            return Context.Set<T>();
        }

        protected bool IsDetached<T>(T entity) where T : class
        {
            return Context.Entry(entity).State == EntityState.Detached;
        }

        protected void SaveContext()
        {
            Context.SaveChanges();
        }

    }
}
