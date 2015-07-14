using System;
using System.Threading.Tasks;
using JaysCoffeeRestApi;
using JaysCoffeeRestApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var i = new PositionLatLng()
            {
                Lat = "23",
                Lng = "10",
                TimeUpdated = new DateTime().ToLocalTime()
            };
            
            new BlobStorageProvider().SaveCordinates(JsonConvert.SerializeObject(
            i));
        }

        [TestMethod]
        public void testgetLatLng()
        {
            Task.Run(() =>
            {
                var i = new BlobStorageProvider().GetCurrentGpsPostion();

                Console.WriteLine(i);
            });
        }
    }
}
