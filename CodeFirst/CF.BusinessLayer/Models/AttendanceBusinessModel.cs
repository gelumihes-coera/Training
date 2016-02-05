using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.BusinessLayer.Models
{
    public class AttendanceBusinessModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public float Grade { get; set; }
    }
}
