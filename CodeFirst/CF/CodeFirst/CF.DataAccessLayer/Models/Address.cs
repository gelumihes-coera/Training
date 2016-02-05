using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.DataAccessLayer.Models
{
    public class Address
    {
        [Key, ForeignKey("Student")]    // one-to-one relationship
        public int StudentId { get; set; }
        public string Streeet { get; set; }
        public string City { get; set; }
        public string County { get; set; }

        public virtual Student Student { get; set; }
    }
}
