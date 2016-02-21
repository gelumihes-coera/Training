using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJsApp.Models
{
    public class BookViewModel
    {
        public string Cover { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
    }
}