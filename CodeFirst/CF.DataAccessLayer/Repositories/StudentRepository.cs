using CF.DataAccessLayer.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace CF.DataAccessLayer.Repositories
{
    // uses only Entity Framework
    public class StudentRepository : IRepository<Student>
    {
        private readonly SchoolDbContext _context;

        public StudentRepository()
        {
            _context = new SchoolDbContext();
        }

        public void Add(Student entity)
        {
            _context.Students.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            Student entity = _context.Set<Student>().Find(id);
            if (entity != null)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _context.Set<Student>().Attach(entity);
                }
                _context.Set<Student>().Remove(entity);
            }
            _context.SaveChanges();
        }

        public Student GetById(int keyValues)
        {
            return _context.Set<Student>().Find(keyValues);
        }

        public IQueryable<Student> GetEntities()
        {
            return _context.Set<Student>();
        }

        public void Update(Student entity, int id)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existing = _context.Set<Student>().Find(id);
            if (existing == null) return;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
