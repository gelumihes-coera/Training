using System.Collections.Generic;

namespace CF.DataAccessLayer.Models
{
    public class Course
    {
        public Course()
        {
            Attendances = new List<Attendance>();
            Teachers = new List<Teacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}