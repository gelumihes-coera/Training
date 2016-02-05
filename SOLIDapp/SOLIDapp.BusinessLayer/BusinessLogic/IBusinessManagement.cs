using System.Collections.Generic;

namespace SOLIDapp.BusinessLayer.BusinessLogic
{
    public interface IBusinessManagement<T> where T : class
    {
        void Add(T entity);

        void Remove(object entity);

        void Update(T entity);

        IEnumerable<T> GetEntities();

        T GetById(int id);
    }
}
