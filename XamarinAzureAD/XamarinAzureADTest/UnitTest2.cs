using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamarinAzureAD.Services;

namespace XamarinAzureADTest
{
    [TestClass]
    public class UnitTest2
    {
        private string _username = "test1@xlentwebapi.onmicrosoft.com";
        private string _password = "newPassword1";

        [TestMethod]
        public void GetNewsTest()
        {
            Task.Run(async () =>
            {
                var news = await new NewsProvider().GetNewsTaskAsync(_username, _password);
                Debug.WriteLine(news.Count);
                Assert.IsTrue(news.Count > 1);

            }).GetAwaiter().GetResult();


        }
    }
}
