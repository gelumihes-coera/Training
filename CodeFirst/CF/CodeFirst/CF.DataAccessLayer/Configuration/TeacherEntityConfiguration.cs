using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CF.DataAccessLayer.Models;

namespace CF.DataAccessLayer.Configuration
{
    public class TeacherEntityConfiguration : EntityTypeConfiguration<Teacher>
    {
        public TeacherEntityConfiguration()
        {
            //many-to-many
            this.HasMany<Course>(c => c.Courses)
                .WithMany(t => t.Teachers)
                .Map(ct =>
                {
                    ct.MapLeftKey("CourseId");
                    ct.MapRightKey("TeacherId");
                    ct.ToTable("TeacherCourse");
                });
        }
    }
}
