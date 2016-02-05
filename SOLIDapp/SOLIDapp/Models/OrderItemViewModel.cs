using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOLIDapp.Models
{
    public class OrderItemViewModel
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}