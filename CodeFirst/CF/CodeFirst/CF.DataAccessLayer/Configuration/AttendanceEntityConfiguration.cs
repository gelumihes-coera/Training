using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CF.DataAccessLayer.Models;

namespace CF.DataAccessLayer.Configuration
{
    public class AttendanceEntityConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceEntityConfiguration()
        {
            //one-to-many 
            this.HasRequired<Student>(s => s.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(s => s.StudentId);

            //one-to-many 
            this.HasRequired<Course>(s => s.Course)
                .WithMany(s => s.Attendances)
                .HasForeignKey(s => s.CourseId);
        }
    }
}
