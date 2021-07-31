using System;
using NUnit.Framework;
using Postman.Utilities;

namespace Postman.DataObjects
{
    public class BillingOrder : DataGenerator
    {
        public string addressLine1 { get; set; }

        public string addressLine2 { get; set; }

        public string city { get; set; }

        public string comment { get; set; }

        public string email { get; set; }

        public string firstName { get; set; }

        public int id { get; set; }

        public int itemNumber { get; set; }

        public string lastName { get; set; }

        public string phone { get; set; }

        public string state { get; set; }

        public string zipCode { get; set; }


        //Data Generation using constructor
        /* public BillingOrder(string addressLine1 = null, string addressLine2 = null, string city = null, string comment = null, string email = null, string firstName = null, int itemNumber = 0, string lastName = null, string phone = null, string state = null, string zipCode = null)
         {
             this.addressLine1 = addressLine1 ?? "test";
             this.addressLine2 = addressLine2 ?? "area";
             this.city = city ?? "Auckland";
             this.comment = comment ?? "Test Data";
             this.email = email ?? "mine@gmail.com";
             this.firstName = firstName ?? "John";
             //this.id = id;   //automatically generated
             this.itemNumber = itemNumber == 0 ? 1 : itemNumber;
             this.lastName = lastName ?? "Power";
             this.phone = phone ?? "123456734567";
             this.state = state ?? "AK";
             this.zipCode = zipCode ?? "12345676";
         }*/

        /* //Random Data Generation
         public BillingOrder(string addressLine1=null, string addressLine2 = null, string city = null, string comment = null, string email = null, string firstName = null, int itemNumber =0, string lastName = null, string phone = null, string state = null, string zipCode = null)
         {
             this.addressLine1 = addressLine1 ?? DataGenerator.GetRandomString(10);
             this.addressLine2 = addressLine2 ?? DataGenerator.GetRandomString(10);
             this.city = city ?? DataGenerator.GetRandomString();
             this.comment = comment ?? TestContext.CurrentContext.Random.GetString();
             this.email = email ?? TestContext.CurrentContext.Random.GetString();
             this.firstName = firstName ?? DataGenerator.FullName();
             this.itemNumber = itemNumber==0 ?1: itemNumber;
             this.lastName = lastName ?? TestContext.CurrentContext.Random.GetString();
             this.phone = phone ?? TestContext.CurrentContext.Random.GetString();
             this.state = state ?? TestContext.CurrentContext.Random.GetString();
             this.zipCode = zipCode ?? TestContext.CurrentContext.Random.GetString();*/

        //Random Data Generation
        public BillingOrder(string addressLine1 = null, string addressLine2 = null, string city = null, string comment = null, string email = null, string firstName = null, string lastName = null, string phone = null, string state = null, string zipCode = null)
        {
            this.addressLine1 = addressLine1 ?? DataGenerator.GetRandomString(10);
            this.addressLine2 = addressLine2 ?? DataGenerator.GetRandomString(20);
            this.city = city ?? DataGenerator.GetRandomString();
            this.comment = comment ?? DataGenerator.GetRandomString();
            this.email = email ?? DataGenerator.GetRandomString() + "@gmail.com";
            this.firstName = firstName ?? DataGenerator.GetRandomString();
            this.id = id;
            this.itemNumber = itemNumber == 0 ? 1 : itemNumber;
            this.lastName = lastName ?? DataGenerator.GetRandomString(); ;
            this.phone = phone ?? DataGenerator.GetRandomString();
            this.state = state ?? DataGenerator.GetRandomString();
            this.zipCode = zipCode ?? DataGenerator.GetRandomString();
        }
    }
}
