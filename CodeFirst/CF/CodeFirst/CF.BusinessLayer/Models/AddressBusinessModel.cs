using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.BusinessLayer.Models
{
    public class AddressBusinessModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Streeet { get; set; }
        public string City { get; set; }
        public string County { get; set; }
    }
}
