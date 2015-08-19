using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XamarinAzureADTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {
        }

        [TestMethod]
        public void AutoMapperValidation()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}