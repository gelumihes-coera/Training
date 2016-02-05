using AutoMapper;
using CF.DataAccessLayer.Models;
using SOLIDapp.DataLayer.Repositories;
using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace CF.DataAccessLayer.Repositories
{
    public class AddressRepository : IRepository<Address>
    {
        private SchoolDbContext Context;

        public AddressRepository()
        {
            Context = new SchoolDbContext();
        }

        public void Add(Address entity)
        {
            try
            {
                Context.Database.ExecuteSqlCommand("EXEC InsertAddress @StudentId, @Streeet, @City, @County",
                    new SqlParameter("@StudentId", entity.StudentId),
                    new SqlParameter("@Streeet", entity.Streeet),
                    new SqlParameter("@City", entity.City),
                    new SqlParameter("@County", entity.County));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(object id)
        {
            try
            {
                Context.Database.ExecuteSqlCommand("EXEC Address_Delete @StudentId", new SqlParameter("@StudentId", id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Address entity, int id)
        {
            try
            {
                Context.Database.ExecuteSqlCommand("EXEC Address_Update @StudentId, @Streeet, @City, @County",
                    new SqlParameter("@StudentId", entity.StudentId),
                    new SqlParameter("@Streeet", entity.Streeet),
                    new SqlParameter("@City", entity.City),
                    new SqlParameter("@County", entity.County));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Address> GetEntities()
        {
            return Context.Set<Address>();
        }

        public Address GetById(params object[] keyValues)
        {
            throw new NotImplementedException();
        }
    }
}
