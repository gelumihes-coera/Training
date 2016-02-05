using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDapp.DataLayer.Repositories
{
    public interface IRepository 
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity, int id) where T : class;
        void Delete<T>(object id) where T : class;
        IQueryable<T> GetEntities<T>() where T : class;
        T GetById<T>(params object[] keyValues) where T : class;
    }
}
