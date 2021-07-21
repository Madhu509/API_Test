using System.Net;
using BillingOrders.API;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Postman.DataObjects;
using RestSharp;

namespace BillingOrders
{
    public class Tests
    {
        BillingOrderAPI billingOrderApi;

        [SetUp]
        public void Setup()
        {
            billingOrderApi = new BillingOrderAPI();
        }

        [Test]
        public void CreateOrderTestCase()
        {
            var expectedOrder = new BillingOrder
            {
                addressLine1 = "Auckland1",
                addressLine2 = "Auckland2",
                city = "Ak",
                comment = "test",
                email = "madhurima.atla@gmail.com",
                firstName = "madhurima",
                lastName = "atla",
                phone = "0223456789",
                zipCode = "123123",
                itemNumber = 1,
                state = "AL"

            };

            string jsonbody = JsonConvert.SerializeObject(expectedOrder);

            IRestResponse response = billingOrderApi.PostOrder(jsonbody);
            TestContext.WriteLine(response.Content);

            //Assertions

            BillingOrder actualOrder = JsonConvert.DeserializeObject<BillingOrder>(response.Content);

            //cleanup

            id = actualOrder.id + "";

            //comparing only one value

            Assert.AreEqual(expectedOrder.firstName, actualOrder.firstName);


            expectedOrder.Should().BeEquivalentTo(actualOrder,
            options => options
            .Excluding(o => o.id));

            //multiple assertions
            Assert.AreEqual(response.StatusCode, "Created");
            Assert.True(response.IsSuccessful);
        }

        /* [Test]
         public void multipleAssertionTest()
         {
             Assert.Multiple(() =>
             {
                 Assert.AreEqual(5, 2, "Real part");
                 Assert.AreEqual(3, 9, "Imaginary part");
             });
         }*/


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

            //data object

            var expectedOrder = new BillingOrder
            {
                addressLine1 = "Auckland1",
                addressLine2 = "Auckland2",
                city = "Ak",
                comment = "test",
                email = "madhurima.atla@gmail.com",
                firstName = "madhurima",
                lastName = "atla",
                phone = "0223456789",
                zipCode = "123123",
                itemNumber = 1,
                state = "AL"

            };

            string jsonbody = JsonConvert.SerializeObject(expectedOrder);

            BillingOrderAPI billingOrderApi = new BillingOrderAPI();

            IRestResponse response = billingOrderApi.PostOrder(jsonbody);
            TestContext.WriteLine(response.Content);

            //Assertions

            BillingOrder actualOrder = JsonConvert.DeserializeObject<BillingOrder>(response.Content);
            id = actualOrder.id + "";
            //comparing only one value

            Assert.AreEqual(expectedOrder.firstName, actualOrder.firstName);

            //Hack

            //expectedOrder.id = actualorder.id;

            //ignoring


            expectedOrder.Should().BeEquivalentTo(actualOrder,
            options => options
            .Excluding(o => o.id));

            //cleanup

            // billingOrderApi.DeleteOrderById(actualOrder.id + "id");

        }
        string id = null;
        [TearDown]
        public void Cleanup()
        {
            if (!string.IsNullOrEmpty(id))
            {
                BillingOrderAPI billingOrderApi = new BillingOrderAPI();
                billingOrderApi.DeleteOrderById(id);
                id = null;
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

        IWebDriver driver = new ChromeDriver();

        //data object

        BillingOrder expectedOrder = new BillingOrder
        {
            addressLine1 = "Auckland1",
            addressLine2 = "Auckland2",
            city = "Ak",
            comment = "test",
            email = "madhurima.atla@gmail.com",
            firstName = "madhurima",
            lastName = "atla",
            phone = "0223456789",
            zipCode = "123123",
            itemNumber = 1,
            state = "AL"

        };

        [Test]
        public void TC_UI_Test()
        {

            BillingOrderPage orderPage = new BillingOrderPage(driver);
            orderPage.SubmitBillingOrder(expectedOrder);

            //Assertion


        }


    }
}


