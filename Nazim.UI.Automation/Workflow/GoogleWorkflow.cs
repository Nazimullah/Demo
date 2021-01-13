using Nazim.Automation.Pages;
using Nazim.Automation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Nazim.Automation.Workflow
{
    /// <summary>
    /// Logic will reside here
    /// </summary>
    public class GoogleWorkflow
    {
        IWebDriver _webDriver;
        Page1 _googlePage;
        Commonutilities _utilities;
        public GoogleWorkflow(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _googlePage = new Page1(_webDriver);
            _utilities = new Commonutilities(_webDriver);
        }

        public (bool, string) ValidateGooglePage(string searchStr, string appUrl)
        {
            _utilities.NavigateUrl(appUrl);
            _googlePage.googleTxtBox.SendKeys(searchStr);
            _googlePage.googleBtn.Click();
            Thread.Sleep(5000);
            return (true, "Testing");
        }
    }
}
