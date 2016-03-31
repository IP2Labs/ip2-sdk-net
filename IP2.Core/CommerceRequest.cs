using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP2.Gateway
{
    public class CommerceRequest:Request
    {
        public string Product { get; set; }
        public Dictionary<string, object> ProductReference { get; set; }
    }
}
