using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IP2.Gateway;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IP2.Tests
{
    [TestClass]
    public class CodeSamples
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

            if (response.ResponseCode ==200)
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
                SubscriptionId = "YOUR_SUBSCRIPTION_ID",
                AccountId = "YOUR_ACCOUNT_ID",
                Username = "YOUR_USER_NAME",
                Password = "YOUR_PASSWORD",
            };
            //Payment  Params 
            var paymentParams = new Dictionary<string, object>();
            paymentParams.Add("AccountId", "256776120056");
            paymentParams.Add("Message", "MESSAGE_THAT_WILL_BE_DISPLAYED_TO_USER_POST_PAYMENT_REQUEST");
            //Product Params 
            var clientParams = new Dictionary<string, object>();
            clientParams.Add("YOURID1", "ID FROM YOUR SYSTEM");
            clientParams.Add("YOURID2", "ID FROM YOUR SYSTEM");
            clientParams.Add("YOURIDN", "ADD AS MANY ID'S");
            //Channel Reference Params 
            var channelParams = new Dictionary<string, object>();
            channelParams.Add("Channel", "SMS/EMAIL/APP");
            channelParams.Add("Account", "PHONE/EMAIL/APPID");
            channelParams.Add("MESSAGE", "MESSAGE TO DELIVER AFTER SUCCESSFULL TRANSACTION");
          
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
