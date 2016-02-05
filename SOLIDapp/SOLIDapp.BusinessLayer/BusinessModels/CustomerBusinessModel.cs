using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDapp.BusinessLayer.BusinessModels
{
    public class CustomerBusinessModel:BaseModel
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int UserId  {get; set; }
    }
}
