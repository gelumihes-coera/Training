using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.DataAccessLayer.Models
{
    public class Student
    {
        public Student()
        {
            Attendances = new List<Attendance>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        //public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
