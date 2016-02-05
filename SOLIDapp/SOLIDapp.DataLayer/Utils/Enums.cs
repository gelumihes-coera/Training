using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDapp.DataLayer.Utils
{
    public enum CustomerTypes
    {
        New,
        Ordinary,
        Silver,
        Gold
    }

    public enum OrderStatus
    {
        Pending,
        Processed,
        Delivering,
        Delivered
    }

    public enum StatusCode
    {
        Available,
        NotAvailable
    }
}
