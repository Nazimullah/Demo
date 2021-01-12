using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nazim.Automation.Pages
{
    public class Page1
    {
        IWebDriver _webdriver = null;
        public Page1(IWebDriver webDriver)
        {
            _webdriver = webDriver;
        }
        public IWebElement googleTxtBox =>
            _webdriver.FindElement(By.Name("q"));

        public IWebElement googleBtn =>
            _webdriver.FindElement(By.Name("btnK"));
    }
}
