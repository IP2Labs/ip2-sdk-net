using IP2.Gateway;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP2.Tests
{
    [TestClass]
    public class CommerceTests
    {
        IP2Gateway gateway;
        CommerceRequest request;

        Product p = Product.AIRTIME; //Change this to test different products 

        [TestInitialize]
        public void Init()
        {
            request = RequestBuilder();
        }

        [TestMethod]
        public void Test_That_Can_Purchase_Commerce_Item()
        {
         
            var response = gateway.Purchase(request);

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
        private CommerceRequest RequestBuilder()
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

            //Product Params 
            var productParams = new Dictionary<string, object>();
            if (p==Product.AIRTIME)
            {
                AirtimeParams(productParams);
            }
            
            //Channel Reference Params 
            var channelParams = new Dictionary<string, object>();
            channelParams.Add("Channel", "SMS");
            channelParams.Add("PhoneNumber", "256776120056");
            channelParams.Add("Message", "You have sent 2000 to bro");
            //MetaData Params 
            var metadataParams = new Dictionary<string, object>();
            metadataParams.Add("Location", "00");


            var request = new CommerceRequest
            {
                RequestId = Guid.NewGuid().ToString(),
                BatchId = Guid.NewGuid().ToString(),
                Amount = 1000,
                Product = "AIRTIME",
                Channel = "SMS",
                Memo = "Memo about the service",
                ChannelReference = channelParams,
                ProductReference = productParams
            };

            var requestFormat = JsonConvert.SerializeObject(request); 

            return request;
        }
        /// <summary>
        /// Airtime params
        /// </summary>
        /// <param name="productParams"></param>
        private static void AirtimeParams(Dictionary<string, object> productParams)
        {
            productParams.Add("Name", "Airtime");
            productParams.Add("PhoneNumber", "256776120056");
            productParams.Add("Amount", "1000");
        }

        enum Product
        {
            NOT_SET, AIRTIME, DATA, TICKETS
        }

        #endregion
    }
}
