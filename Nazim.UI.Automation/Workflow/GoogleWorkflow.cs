using Nazim.Automation.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nazim.Automation.Workflow
{
    /// <summary>
    /// Logic will reside here
    /// </summary>
    public class GoogleWorkflow
    {
        IWebDriver _webDriver;
        Page1 _googlePage;
        public GoogleWorkflow(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _googlePage = new Page1(_webDriver);
        }


        public (bool, string) ValidateGooglePage()
        {
            return (true, "Testing");
        }
    }
}
