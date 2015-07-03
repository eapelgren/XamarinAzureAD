using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamarinAzureAD.Model;
using XamarinAzureAD.Services;
using XamarinAzureAD.ViewModel;

namespace XamarinAzureADTest
{
    [TestClass]
    public class UnitTest1
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
                Assert.IsTrue(news.Count > 5);                
            
            }).GetAwaiter().GetResult();


        }
    }
}
