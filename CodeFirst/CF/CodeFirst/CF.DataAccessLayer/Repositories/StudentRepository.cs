using CF.DataAccessLayer.Models;
using SOLIDapp.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.DataAccessLayer.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly SchoolDbContext Context;

        public StudentRepository()
        {
            Context = new SchoolDbContext();
        }

        public void Add(Student entity)
        {
            Context.Students.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(object id)
        {
            Student entity = Context.Set<Student>().Find(id);
            if (entity != null)
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                {
                    Context.Set<Student>().Attach(entity);
                }
                Context.Set<Student>().Remove(entity);
            }
            Context.SaveChanges();
        }

        public Student GetById(params object[] keyValues)
        {
            return Context.Set<Student>().Find(keyValues);
        }

        public IQueryable<Student> GetEntities()
        {
            return Context.Set<Student>();
        }

        public void Update(Student entity, int id)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existing = Context.Set<Student>().Find(id);
            if (existing == null) return;
            Context.Entry(existing).CurrentValues.SetValues(entity);
            Context.SaveChanges();
        }
    }
}
