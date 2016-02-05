using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDapp.BusinessLayer.BusinessModels
{
    public class BaseModel:IEntityWithId
    {
        public  int Id { get; set; }
    }
}
