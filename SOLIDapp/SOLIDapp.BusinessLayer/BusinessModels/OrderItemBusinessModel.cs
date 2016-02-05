using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDapp.BusinessLayer.BusinessModels
{
    public class OrderItemBusinessModel:BaseModel
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
