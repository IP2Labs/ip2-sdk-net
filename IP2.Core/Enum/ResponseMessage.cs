using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP2.Gateway.Enum
{
    public enum ResponseMessage
    {
        NO_RESPONSE=999, 
        OK=100,
        INVALID_ACCOUNT_DETAILS=101,
        INSUFFICIENT_BALANCE=102, 
        APPLICATION_ERROR=500
    }
}
