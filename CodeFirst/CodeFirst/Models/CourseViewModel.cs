using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CF.BusinessLayer.Models;

namespace CodeFirst.Models
{
    public class CourseViewModel
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
    }
}