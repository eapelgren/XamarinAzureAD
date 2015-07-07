

using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamarinAzureAD.Services;

namespace XamarinAzureADTest
{
    [TestClass]
    public class UnitTest1
    {
        private string _username = "test1@xlentwebapi.onmicrosoft.com";
        private string _password = "newPassword1";

        [TestMethod]
        public void TestCorrectUsernamePassword()
        {
            var authProvider = new AuthenticationProvider().LoginAdTaskAsync(_username, _password);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpException))]
        public void TestFalseUsernamePassword()
        {

            var authProvider = new AuthenticationProvider().LoginAdTaskAsync("dsfdsf", "asdasd");

        }

        [TestMethod]
        [ExpectedException(typeof(HttpException))]
        public void TestNullUsernamePassword()
        {
            var authProvider = new AuthenticationProvider().LoginAdTaskAsync(null, null);
        }


    }
}
