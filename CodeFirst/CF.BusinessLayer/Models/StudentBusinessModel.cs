using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.BusinessLayer.Models
{
    public class StudentBusinessModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
    }
}
