using System;
using System.Collections;
using System.IO;
using System.Net;
using BillingOrders.API;
using FluentAssertions;
using LumenWorks.Framework.IO.Csv;
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

        [TestCaseSource(nameof(BillingOrderTestCaseData))]
        public void CreateOrderTestCase(BillingOrder expectedOrder, string status)
        {

            //convert object to json
            string jsonbody = JsonConvert.SerializeObject(expectedOrder);

            //insert json body into post method
            IRestResponse response = billingOrderApi.PostOrder(jsonbody);
            TestContext.WriteLine(response.Content);

            //Deserialize response

            BillingOrder actualOrder = JsonConvert.DeserializeObject<BillingOrder>(response.Content);

            id = actualOrder.id + "";

            //comparing only one value

            // if(status.Equals("valid"))

            //Assertions

            //Assert.AreEqual(expectedOrder.firstName, actualOrder.firstName);

            expectedOrder.Should().BeEquivalentTo(actualOrder, options => options.Excluding(o => o.id));


        }

        //Creating test case Data Object

        public static IEnumerable BillingOrderTestCaseData
        {
            get
            {
                yield return new TestCaseData(new BillingOrder
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
                    itemNumber = 0,
                    state = "AL"

                }, "valid").SetName("Create Billing order test case");


                // yield return new TestCaseData(new BillingOrder(), "valid").SetName("Default Test Data");
                //yield return new TestCaseData(new BillingOrder(email: "123"), "invalid").SetName("Email validation data");


            }
        }


        //Multiple Assertions using Lambda expression
        /* [Test]
         public void multipleAssertionTest()
         {
             Assert.Multiple(() =>
             {
                 Assert.AreEqual(5, 2, "Real part");
                 Assert.AreEqual(3, 9, "Imaginary part");
             });
         }*/

        //Cleanup

        string id;
        [TearDown]
        public void CleanUp()
        {
            if (string.IsNullOrEmpty(id))
            {
                billingOrderApi.DeleteOrderById(id);
            }
        }

        // [Test]
        public void TC_GetOrderById()
        {
            BillingOrderAPI billingOrder = new BillingOrderAPI();
            IRestResponse response = billingOrder.GetOrdersById("10");
            TestContext.WriteLine(response.Content);

            //Assertions pending
        }
        // [Test]
        public void TC_DeleteOrder()
        {
            BillingOrderAPI billingOrder = new BillingOrderAPI();
            IRestResponse response = billingOrder.DeleteOrderById("2");
            TestContext.WriteLine(response.Content);

            //Assertions pending
        }

        // [Test]
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

            //Assert.AreEqual(expectedOrder.firstName, actualOrder.firstName);

            //Hack

            // expectedOrder.id = actualOrder.id;

            //ignoring
            expectedOrder.Should().BeEquivalentTo(actualOrder, options => options.Excluding(o => o.id));

            //cleanup

            // billingOrderApi.DeleteOrderById(actualOrder.id + "id");


            /* string id = null;
             [TearDown]
             public void Cleanup()
             {
                 if (!string.IsNullOrEmpty(id))
                 {
                     BillingOrderAPI billingOrderApi = new BillingOrderAPI();
                     billingOrderApi.DeleteOrderById(id);
                     id = null;
                 }*/
        }
    



       // [Test]
        public void TC_GetAllRecords()
        {
            BillingOrderAPI billingOrder = new BillingOrderAPI();
            IRestResponse response = billingOrder.GetAllRecords();
            TestContext.WriteLine(response.Content);

            //Assertions pending
        }
       // [Test]
        public void TC_PutOrder()
        {
            string body = $"{{\"addressLine1\":\"auckland\", \"addressLine2\":\"nz\", \"city\":\"penrose\", \"comment\":\"testing\", \"email\":\"madhurima.atla@gmail.com\", \"firstName\":\"naina\", \"itemNumber\":0, \"lastName\":\"atla\", \"phone\":\"0223065400\", \"state\":\"AL\", \"zipCode\":\"123123\"}}";

            BillingOrderAPI billingOrder = new BillingOrderAPI();

            //pending

            IRestResponse response = billingOrder.PutOrder("100", body);
            TestContext.WriteLine(response.Content);

            //Assertions pending....



        }

        [TestCaseSource(nameof(BillingOrderCSVTestData))]
        public void CreateOrderCSVTestCase(BillingOrder expectedOrder, string status)
        {
            //convert object to json
            string jsonbody = JsonConvert.SerializeObject(expectedOrder);

            //Insert json body into post method
            IRestResponse response = billingOrderApi.PostOrder(jsonbody);

            //Deserialize response
            BillingOrder actualOrder = JsonConvert.DeserializeObject<BillingOrder>(response.Content);

            //Assertion
            //expectedOrder.Should().BeEquivalentTo(actualOrder, options => options.Excluding(o => o.id));

        }



        //creating Test case data Object
        public static IEnumerable BillingOrderCSVTestData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"TestData\BillingOrderTestData.csv";
            using var csv = new CsvReader(new StreamReader(Path.Combine(path)), true);
            {
                while (csv.ReadNextRecord())
                {
                    //test data..
                    string description = csv["description" + " " + "firstname"]; //csv[11];

                    BillingOrder order = new BillingOrder(addressLine1: csv["addressLine1"],
                   addressLine2: csv["addressLine2"],
                   city: csv["city"],
                   comment: csv["comment"],
                   email: csv["email"],
                   firstName: csv["firstname"],
                   lastName: csv["lastname"],
                   phone: csv["phone"],
                   zipCode: csv["zipCode"],
                   state: csv["state"]);


                    yield return new TestCaseData(order).SetName(description);

                }

            }

        }


    }
}


