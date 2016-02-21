using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJsApp.Models
{
    public class AuthorViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int WrittenBooks { get; set; }
    }
}