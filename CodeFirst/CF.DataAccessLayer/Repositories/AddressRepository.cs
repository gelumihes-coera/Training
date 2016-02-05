using AutoMapper;
using CF.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace CF.DataAccessLayer.Repositories
{
    // uses Entity Framework to call and execute stored procedures
    public class AddressRepository : IRepository<Address>
    {
        private readonly SchoolDbContext _context;

        public AddressRepository()
        {
            _context = new SchoolDbContext();
        }

        public void Add(Address entity)
        {
            // execute the mapped stored procedure
            _context.Addresses.Add(entity);
            _context.SaveChanges();

            //if address is not mapped to an insert stored procedure, we may use:
            //////////Context.Database.SqlQuery<Address>("Address_Insert @StudentId, @Streeet, @City, @County",
            //////////    new SqlParameter("@StudentId", entity.StudentId),
            //////////    new SqlParameter("@Streeet", entity.Streeet),
            //////////    new SqlParameter("@City", entity.City),
            //////////    new SqlParameter("@County", entity.County)).ToList();
            //the store procedure must have a select statement to return the entity it matches <Address>:
            //////////INSERT INTO Addresses(StudentId, Streeet, City, County)
            //////////VALUES(@StudentId, @Streeet, @City, @County)
            //////////SELECT StudentId, Streeet, City, County FROM Addresses WHERE StudentId = @StudentId
        }

        public void Delete(object id)
        {
            // execute the mapped stored procedure
            Address entity = _context.Set<Address>().Find(id);
            if (entity != null)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _context.Set<Address>().Attach(entity);
                }
                _context.Set<Address>().Remove(entity);
            }
            _context.SaveChanges();

            //if address is not mapped to a delete stored procedure, we may use:
            //////Context.Database.SqlQuery<Address>("Address_Delete @StudentId", new SqlParameter("@StudentId", id)).ToList();
            //the store procedure must have a select statement, too
        }

        public void Update(Address entity, int id)
        {
            // execute the mapped stored procedure
            if (entity != null)
            {
                var existing = _context.Set<Address>().Find(id);
                if (existing == null) return;
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException(nameof(entity));
            }

            //if address is not mapped to an update stored procedure, we may use:
            ////////Context.Database.SqlQuery<Address>("Address_Update @StudentId, @Streeet, @City, @County",
            ////////        new SqlParameter("@StudentId", entity.StudentId),
            ////////        new SqlParameter("@Streeet", entity.Streeet),
            ////////        new SqlParameter("@City", entity.City),
            ////////        new SqlParameter("@County", entity.County)).ToList();
            //the store procedure must have a select statement, too
        }

        public IQueryable<Address> GetEntities()
        {
            //execute stored procedure "Addresses_Get"
            return _context.Database.SqlQuery<Address>("Addressess_Get").ToList().AsQueryable();
        }

        public Address GetById(int id)
        {
            //execute stored procedure "Addresses_GetById"
            return _context.Database.SqlQuery<Address>("Address_GetById @Id", new SqlParameter("@Id", id)).SingleOrDefault();
        }
    }
}
