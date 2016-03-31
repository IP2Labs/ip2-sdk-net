using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP2.Accounts
{
    public class IP2Accounts
    {
        private IHmacRestClient hmacRestClient;


        public string SubscriptionId { get; set; }
        public string AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Enviroment Enviroment { get; set; }
    }
}
