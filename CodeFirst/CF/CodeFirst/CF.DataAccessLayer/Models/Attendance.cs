using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.DataAccessLayer.Models
{
    public class Attendance
    {
        // composed primary key
        [Key, Column(Order = 0), ForeignKey("Student")]
        public int StudentId { get; set; }

        [Key, Column(Order = 1), ForeignKey("Course")]
        public int CourseId { get; set; }

        public float Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
