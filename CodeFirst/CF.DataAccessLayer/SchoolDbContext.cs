using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CF.DataAccessLayer.Configuration;
using CF.DataAccessLayer.Models;

namespace CF.DataAccessLayer
{
    public class SchoolDbContext : System.Data.Entity.DbContext
    {
        public SchoolDbContext() : base("CodeFirstDb")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SchoolDbContext>());
        }

        // entity sets
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        //Configure domain classes using Fluent API here.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //map stored procedured to entities
            modelBuilder.Entity<Address>().MapToStoredProcedures(s => s.Insert(i => i.HasName("[dbo].[Address_Insert]")));
            modelBuilder.Entity<Address>().MapToStoredProcedures(s => s.Delete(i => i.HasName("[dbo].[Address_Delete]")));
            modelBuilder.Entity<Address>().MapToStoredProcedures(s => s.Update(i => i.HasName("[dbo].[Address_Update]")));

            base.OnModelCreating(modelBuilder);

            //configure entities
            modelBuilder.Configurations.Add(new AttendanceEntityConfiguration());
            modelBuilder.Configurations.Add(new StudentEntityConfiguration());
            modelBuilder.Configurations.Add(new TeacherEntityConfiguration());

        }
    }
}