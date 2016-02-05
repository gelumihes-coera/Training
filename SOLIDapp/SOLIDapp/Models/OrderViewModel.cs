using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDapp.Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double? Total { get; set; }
        public System.DateTime Date { get; set; }
        public int StatusId { get; set; }
    }
}
