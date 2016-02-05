using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDapp.BusinessLayer.BusinessModels
{
    class UserBusinessModel:BaseModel
    {
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
