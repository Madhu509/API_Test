using BillingOrders.API;
using NUnit.Framework;
using RestSharp;

namespace BillingOrders
{
    public class Tests
    {


        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TC_GetOrderById()
        {
            BillingOrderAPI billingOrder = new BillingOrderAPI();
            IRestResponse response = billingOrder.GetOrdersById("10");
            TestContext.WriteLine(response.Content);

            //Assertions pending
        }
        [Test]
        public void TC_DeleteOrder()
        {
            BillingOrderAPI billingOrder = new BillingOrderAPI();
            IRestResponse response = billingOrder.DeleteOrderById("2");
            TestContext.WriteLine(response.Content);

            //Assertions pending
        }

        [Test]
        public void TC_PostOrder()
        {
            for (int i = 1; i <= 100; i++)
            {
                string body = $"{{\"addressLine1\":\"auckland{i}\", \"addressLine2\":\"nz{i}\", \"city\":\"penrose\", \"comment\":\"testing\", \"email\":\"madhurima.atla@gmail.com\", \"firstName\":\"naina{i}\", \"itemNumber\":0, \"lastName\":\"atla{i}\", \"phone\":\"0223065400\", \"state\":\"AL\", \"zipCode\":\"123123\"}}";

                BillingOrderAPI billingOrder = new BillingOrderAPI();

                IRestResponse response = billingOrder.PostOrder(body);
                TestContext.WriteLine(response.Content);

                //Assertions pending
            }
        }

        [Test]
        public void TC_GetAllRecords()
        {
            BillingOrderAPI billingOrder = new BillingOrderAPI();
            IRestResponse response = billingOrder.GetAllRecords();
            TestContext.WriteLine(response.Content);

            //Assertions pending
        }
        [Test]
        public void TC_PutOrder()
        {
            string body = $"{{\"addressLine1\":\"auckland\", \"addressLine2\":\"nz\", \"city\":\"penrose\", \"comment\":\"testing\", \"email\":\"madhurima.atla@gmail.com\", \"firstName\":\"naina\", \"itemNumber\":0, \"lastName\":\"atla\", \"phone\":\"0223065400\", \"state\":\"AL\", \"zipCode\":\"123123\"}}";

            BillingOrderAPI billingOrder = new BillingOrderAPI();

            //pending

            IRestResponse response = billingOrder.PutOrder("100", body);
            TestContext.WriteLine(response.Content);

            //Assertions pending
        }


    }
}

