using System.Linq;

namespace CF.DataAccessLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity, int id);

        void Delete(object id);

        IQueryable<T> GetEntities();

        T GetById(int keyValues);
    }
}
