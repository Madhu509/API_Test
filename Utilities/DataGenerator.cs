using System;
using NUnit.Framework;

namespace Postman.Utilities
{
    public class DataGenerator
    {
        static string a1 = "abcdefghijklmnopqrstuvwxyz";
        static string a2 = "ABCDEFGHIJKLMNOPQRSTUVWXYNZ";
        static string num = "123456789";
        public static string GetRandomString(int len=10)
        {
            return TestContext.CurrentContext.Random.GetString(10, $"{a1}{a2}");

        }

        public static string GetRandomStringInt(int len = 10)
        {
            return TestContext.CurrentContext.Random.GetString(10, $"{num}");

        }
        //Function

        public static string FullName1()
        {
            return Faker.Name.FullName();
        }

        //property

        //public static string FullName()=> Faker.Name.FullName();

    }

}


