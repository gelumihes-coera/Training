using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.BusinessLayer.Models
{
    public class CourseBusinessModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
    }
}
