using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CF.DataAccessLayer.Models;

namespace CF.DataAccessLayer.Configuration
{
    public class StudentEntityConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentEntityConfiguration()
        {
            //configuration
            this.Property(p => p.BirthDate)
                .HasColumnType("datetime2");
        }
    }
}
