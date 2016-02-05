using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CF.BusinessLayer.Models;
using CF.DataAccessLayer.Models;

namespace CodeFirst.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public string Address { get; set; }
    }
}