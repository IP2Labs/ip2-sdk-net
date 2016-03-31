using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP2.Gateway
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public string AccountId { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string Channel { get; set; }
        public string PaymentMethod { get; set; }
        public string Service { get; set; }
        public decimal Amount { get; set; }
        public string Memo { get; set; }
        public string Status { get; set; }
        public string CreationDate { get; set; }
        public string StatusMessage { get; set; }

    }
}
