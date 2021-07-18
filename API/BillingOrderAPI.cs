using System;
using RestSharp;

namespace BillingOrders.API
{
    public class BillingOrderAPI
    {
        private readonly string baseUrl = "http://localhost:8080";

        public IRestResponse GetOrdersById(string id)
        {
            //setting things
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.GET);

            //Execution
            IRestResponse response = client.Execute(request);

            return response;

        }

        public IRestResponse GetAllRecords()
        {
            //setting things
            var client = new RestClient($"{baseUrl}/BillingOrder");
            var request = new RestRequest(Method.GET);

            //Execution
            IRestResponse response = client.Execute(request);

            return response;

        }

        public IRestResponse DeleteOrderById(string id)
        {
            //setting things
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.DELETE);

            //Execution
            IRestResponse response = client.Execute(request);

            return response;

        }

        public IRestResponse PostOrder(string body)
        {
            //setting things
            var client = new RestClient($"{baseUrl}/BillingOrder");
            var request = new RestRequest(Method.POST);
            //header
            request.AddHeader("Content-Type", "application/json");
            //post
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            //Execution
            IRestResponse response = client.Execute(request);

            return response;

        }
        public IRestResponse PutOrder(string id, string body)
        {
            //setting things
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.PUT);
            //header
            request.AddHeader("Content-Type", "application/json");
            //post
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            //Execution
            IRestResponse response = client.Execute(request);

            return response;

        }
    }
}
