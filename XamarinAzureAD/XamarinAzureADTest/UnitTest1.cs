using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamarinAzureAD.RestServices.XlentRestService;
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
            var vm = new NewsPageViewModel();




        }
    }
}
