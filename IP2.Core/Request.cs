using IP2.Gateway.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP2.Gateway
{
    public abstract class Request
    {
        public string RequestId { get; set; }
        public string BatchId { get; set; }
        public decimal Amount { get; set; }
        public string Memo { get; set; }
        public string Channel { get; set; }
        public Dictionary<string, object> ChannelReference { get; set; }
        
        public string MetaData { get; set; }
    }
}
