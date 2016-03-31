﻿using IP2.Gateway.Enum;
using IP2.Hmac.Auth.Hmac;
using IP2.Hmac.Auth.Rest;
using IP2.Hmac.Hash;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP2.Gateway
{
    public class IP2Gateway
    {
        private IHmacRestClient hmacRestClient;
        

        public string SubscriptionId { get; set; }
        public string AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Enviroment Enviroment { get; set; }


        /// <summary>
        /// Payment deposit 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response Deposit(PaymentRequest request)
        {
            SelectEnviroment();
            AddMetaData(request);
            var resource = "debitpayments"; 
            IHmacRestRequest hmacRestRequest = RequestBuilder(request, resource);
            var resp = hmacRestClient.Execute(hmacRestRequest);
            return GetResponse(resp);
        }
        /// <summary>
        /// Payment request payment 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response RequestPayment(PaymentRequest request)
        {
            SelectEnviroment();
            AddMetaData(request);
            var resource = "creditpayments";
            IHmacRestRequest hmacRestRequest = RequestBuilder(request, resource);
            var resp = hmacRestClient.Execute(hmacRestRequest);
            return GetResponse(resp); 
        }
        /// <summary>
        /// Commerce purchase 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response Purchase(CommerceRequest request)
        {
            SelectEnviroment();
            AddMetaData(request);
            var resource = "debitwallets";
            IHmacRestRequest hmacRestRequest = RequestBuilder(request, resource);
            var resp = hmacRestClient.Execute(hmacRestRequest);
            return GetResponse(resp); 
        }

        public Account GetAccountDetails()
        {
            Account account = null; 
            SelectEnviroment();
            var resource = "accounts";
            var hmacRestRequest = new HmacRestRequest(Method.GET);
            hmacRestRequest.RequestFormat = DataFormat.Json;
            hmacRestRequest.Resource = new StringBuilder().Append(resource).Append("/{accountId}?subscriptionId={subscriptionId}").ToString();
            hmacRestRequest.AddUrlSegment("accountId", this.AccountId);
            hmacRestRequest.AddUrlSegment("subscriptionId", this.SubscriptionId);
            var resp = hmacRestClient.Execute(hmacRestRequest);
            if (resp.RestResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                account = resp.DataToEntity<Account>();
            }
            else
            {
                throw new IP2GatewayException(resp.RestResponse.StatusDescription); 
            }
            return account; 
        }

        public List<Transaction> GetTransactions()
        {

            List<Transaction> transactions = null;
            SelectEnviroment();
            var resource = "SubscriptionTransactions";
            var hmacRestRequest = new HmacRestRequest(Method.GET);
            hmacRestRequest.RequestFormat = DataFormat.Json;
            hmacRestRequest.Resource = new StringBuilder().Append(resource).Append("/{Id}").ToString();
            hmacRestRequest.AddUrlSegment("Id", this.SubscriptionId);
            //hmacRestRequest.AddUrlSegment("subscriptionId", this.SubscriptionId);
            var resp = hmacRestClient.Execute(hmacRestRequest);
            if (resp.RestResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                transactions = resp.DataToEntity<List<Transaction>>();
            }
            else
            {
                throw new IP2GatewayException(resp.RestResponse.StatusDescription);
            }
            return transactions; 
        }

        #region Private methods
        /// <summary>; 
        /// Select enviroment 
        /// </summary>
        private void SelectEnviroment()
        {
            if (this.Enviroment == IP2.Gateway.Enum.Enviroment.SANDBOX)
            {
                hmacRestClient = new HmacRestClient("http://ec2-54-148-117-189.us-west-2.compute.amazonaws.com/api/", this.Username, this.Password, HmacSize.HMAC_SHA512, HashSize.HASH_SHA512);
            }
            else if (this.Enviroment == IP2.Gateway.Enum.Enviroment.PRODUCTION)
            {
                hmacRestClient = new HmacRestClient("http://productionip2.iwiafrica/api/", this.Username, this.Password, HmacSize.HMAC_SHA512, HashSize.HASH_SHA512);
            }
            else
            {
                throw new IP2GatewayException("Enviroment is not set");
            }
        }
        /// <summary>
        /// Build request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        private IHmacRestRequest RequestBuilder(Request request, string resource)
        {
            var hmacRestRequest = new HmacRestRequest(Method.POST);
            hmacRestRequest.RequestFormat = DataFormat.Json;
            hmacRestRequest.Resource = new StringBuilder().Append(resource).Append("?accountId={accountId}&subscriptionId={subscriptionId}").ToString();
            hmacRestRequest.AddUrlSegment("accountId", this.AccountId);
            hmacRestRequest.AddUrlSegment("subscriptionId", this.SubscriptionId);
            hmacRestRequest.RestRequest.AddJsonBody(request);
            return hmacRestRequest; 
        }
        /// <summary>
        /// Add metadata
        /// </summary>
        /// <param name="request"></param>
         void AddMetaData(Request request)
        {
            var metaDataParams = new Dictionary<string, object>();
            var metaData = JsonConvert.SerializeObject(metaDataParams);
            request.MetaData = metaData;
        } 
        //Get response 
         private static Response GetResponse(IHmacRestResponse resp)
         {
             if (resp.RestResponse.StatusCode == System.Net.HttpStatusCode.OK)
             {
                 return Ok();
             }
             else
             {
                 return new Response
                 {
                     ResponseCode = 300, //Need to work on the response codes  
                     ResponseMessage = resp.RestResponse.StatusDescription
                 };
             }
         }
        //OK 
         private static Response Ok()
         {
             return new Response
             {
                 ResponseCode = 200,
                 ResponseMessage = "OK"
             };
         }
        #endregion
    }
}
