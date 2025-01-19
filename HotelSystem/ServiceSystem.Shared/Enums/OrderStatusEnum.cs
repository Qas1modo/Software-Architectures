using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelServiceSystem.Shared.Enums
{
    public enum OrderStatusEnum
    {
        Created,
        Cancelled,
        Confirmed,
        InProgress,
        Fulfilled,
    }
}
