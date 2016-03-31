using IP2.Gateway;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP2.Tests
{
    [TestClass]
    public class TransactionTests
    {
        IP2Gateway gateway;

        [TestInitialize]
        public void Init()
        {

        }
        [TestMethod]
        public void Test_That_Can_Get_Account_Details()
        {
            gateway = new IP2Gateway
            {
                Enviroment = IP2.Gateway.Enum.Enviroment.SANDBOX,
                SubscriptionId = "09231504302F2456B4B6AA46DAA815B2D9C15EAA4E",
                AccountId = "256758649804",
                Username = "iwadmin",
                Password = "ilov3J3sus",
            };

            var transactions = gateway.GetTransactions();

        }
    }
}
