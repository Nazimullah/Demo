using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nazim.Automation.Utilities
{
    public class Commonutilities
    {
        IWebDriver _webDriver;
        public Commonutilities(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public static string environment = string.Empty;
        public static void SetConfigValues(TestContext testContext)
        {
            environment = testContext.Properties["Environment"].ToString();
        }

        public void NavigateUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
            _webDriver.Manage().Window.Maximize();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public IWebElement Elemt_Wait_By_ID_Visbility(string iD, double waitTime)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromMilliseconds(waitTime));
            var clickableElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(iD)));
            return clickableElement;
        }

        public IWebElement Elemt_Wait_By_Name_Visbility(string name, double waitTime)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromMilliseconds(waitTime));
            var clickableElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Name(name)));
            return clickableElement;
        }
    }
}
