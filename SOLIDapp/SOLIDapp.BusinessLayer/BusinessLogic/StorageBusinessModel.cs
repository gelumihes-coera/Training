using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDapp.BusinessLayer.BusinessModels;

namespace SOLIDapp.BusinessLayer.BusinessLogic
{
    public class StorageBusinessModel:BaseModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
