using Nazim.Automation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nazim.Automation.Pages
{
    public class Page1
    {
        IWebDriver _webdriver = null;
        Commonutilities _commonUtilities;
        public Page1(IWebDriver webDriver)
        {
            _webdriver = webDriver;
            _commonUtilities = new Commonutilities(_webdriver);
        }
        public IWebElement googleTxtBox =>
            _commonUtilities.Elemt_Wait_By_Name_Visbility("q",60000);

        public IWebElement googleBtn =>
            _commonUtilities.Elemt_Wait_By_Name_Visbility("btnK",60000);
    }
}
