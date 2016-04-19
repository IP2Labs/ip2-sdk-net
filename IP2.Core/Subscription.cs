using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP2.Gateway
{
    public class Subscription
    {
        public string SubscriptionId { get; set; }
        public string Name { get; set; }
        public string IpnUsername { get; set; }
        public string SubscriptionStatus { get; set; }
        public string Description { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string LargeImage { get; set; }
        public string ThumbNail { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
