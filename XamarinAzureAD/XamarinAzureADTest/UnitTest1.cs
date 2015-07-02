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
                var news = await new XlentAzureRestServicePCL().GetNewsTaskAsync(_username, _password);

                foreach (ObservableNews newse in news)
                {
                    Debug.WriteLine(newse.Header);
                }
                Debug.WriteLine(news);
                Assert.IsNotNull(news);
            }).GetAwaiter().GetResult();


        }
    }
}
