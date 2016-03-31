using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP2.Gateway
{
    public class PaymentRequest:Request
    {
        public string Payment { get; set; }
        public Dictionary<string, object> PaymentReference { get; set; }
        public Dictionary<string, object> ClientReference { get; set; }
    }
}
