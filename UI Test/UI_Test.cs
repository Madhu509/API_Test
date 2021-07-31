using System;
using System.Collections;
using BillingOrders.API;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Postman.DataObjects;
using RestSharp;

namespace Postman.UITest
{
    [TestFixture]
    public class UI_Test
    {
        
        IWebDriver driver = new ChromeDriver();

        // Create data object

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
