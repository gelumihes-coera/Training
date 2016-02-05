using CF.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Models
{
    public class AddressViewModel
    {
        public int StudentId { get; set; }
        [Display(Name = "Student")]
        public string StudentName { get; set; }
        public string Streeet { get; set; }
        public string City { get; set; }
        public string County { get; set; }

        public List<SelectListItem> Students { get; set; }
    }
}