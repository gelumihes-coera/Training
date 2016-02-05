using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDapp.DataLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity, int id);
        void Delete(object id);
        IQueryable<T> GetEntities();
        T GetById(params object[] keyValues);
    }
}
