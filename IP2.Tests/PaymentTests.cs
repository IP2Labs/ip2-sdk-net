using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IP2.Gateway;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IP2.Tests
{
    [TestClass]
    public class PaymentTests
    {
        IP2Gateway gateway;
        PaymentRequest request;

        [TestInitialize]
        public void Init()
        {
            request = RequestBuilder();
        }
        /// <summary>
        /// Deposit money onto account
        /// </summary>
        [TestMethod]
        public void Test_That_Can_Deposit_Money_On_MTN_Mobile_Money_Uganda()
        {
           
            var response = gateway.Deposit(request); 

            //check the response 

            if (response.ResponseCode ==100)
            {
                //OK 
            }
            else
            {
                //NOT OK  
            }
        }
        /// <summary>
        /// Request payment from account 
        /// </summary>
        [TestMethod]
        public void Test_That_Request_Payment_From_MTN_Mobile_Money_Uganda()
        {
          

            var response = gateway.RequestPayment(request);

            //check the response 

            if (response.ResponseCode == 100)
            {
                //OK 
            }
            else
            {
                //NOT OK  
            }
        }

        #region Helpers
        private PaymentRequest RequestBuilder()
        {
            ///Create the gateway 

            gateway = new IP2Gateway
            {
                Enviroment = IP2.Gateway.Enum.Enviroment.SANDBOX,
                SubscriptionId = "092316011101C489965F8449899C7D171CC8CAF4E6",
                AccountId = "256758649804",
                Username = "iwadmin",
                Password = "ilov3J3sus",
            };
            //Payment  Params 
            var paymentParams = new Dictionary<string, object>();
            paymentParams.Add("AccountId", "256776120056");
            paymentParams.Add("Message", "Please buy ticket for me");
            //Product Params 
            var clientParams = new Dictionary<string, object>();
            clientParams.Add("CartId", "7987987987987987987987989");
            clientParams.Add("ShopperId", "79879879879879879");
            //Channel Reference Params 
            var channelParams = new Dictionary<string, object>();
            channelParams.Add("Channel", "SMS");
            channelParams.Add("PhoneNumber", "256776120056");
            channelParams.Add("Message", "You have sent 2000 to bro");
            //MetaData Params 
            var metadataParams = new Dictionary<string, object>();
            metadataParams.Add("Location", "00");


            var request = new PaymentRequest
            {
                RequestId = Guid.NewGuid().ToString(),
                BatchId = Guid.NewGuid().ToString(),
                Amount = 1000,
                Channel = "SMS",
                Payment = "MTNUGMOMO",
                Memo = "Memo about the service",
                ChannelReference = channelParams,
                PaymentReference = paymentParams,
                ClientReference = clientParams
            };

            return request;
        } 
        #endregion
    }
}
