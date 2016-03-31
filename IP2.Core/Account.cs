using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP2.Gateway
{
    public class Account
    {
        public string AccountId { get; set; }
        public string AccountType { get; set; }
        public string CurrencyCode { get; set; }
        public string CountryCode { get; set; }
        public decimal TotalAmount { get; set; }
        public string AccountStatus { get; set; }
        public string Balance { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
