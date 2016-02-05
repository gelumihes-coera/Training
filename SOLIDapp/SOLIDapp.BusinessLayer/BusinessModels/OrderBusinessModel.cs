using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDapp.BusinessLayer.BusinessModels
{
    public class OrderBusinessModel:BaseModel
    {
        public int CustomerId { get; set; }
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public double? Total { get; set; }
        public System.DateTime Date { get; set; }
        public int StatusId { get; set; }
    }
}
