using DriversCSAT.UI.Automation.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nazim.UI.Automation.BaseClass
{
    [TestClass]
    [TestCategory("BaseClass")]
    public class TestBaseClass
    {
        public static IWebDriver _webDriver;
        protected static TestContext _testContext;

        public TestBaseClass()
        {


        }

        [TestInitialize()]
        public void TestInitialize()
        {
            //_webDriver = WebDriver.SetupWebdriver(_testContext.Properties["WebDriver"].ToString(), string.Empty, string.Empty,
            //    string.Empty, string.Empty, string.Empty, bool.Parse(_testContext.Properties["LocalRun"].ToString()));
            //_webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            //_webDriver.Quit();
        }
    }
}
