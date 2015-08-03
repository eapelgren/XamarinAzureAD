using System;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamarinAzureAD.Handler;

namespace XamarinAzureADTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {
            MapperConfiguration.Init();
        }

        [TestMethod]
        public void AutoMapperValidation()
        {
            Mapper.AssertConfigurationIsValid();
        }


    }
}
