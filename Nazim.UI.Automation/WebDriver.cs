using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Net;

namespace DriversCSAT.UI.Automation.Utilities
{
    public class WebDriver
    {
        public static IWebDriver SetupWebdriver(string browserName, string env, string operatingSystem,
            string buldName, string vrsion, string testCaseName, bool localRun)
        {
            #region Get Parameters

            // Get from TestContext
            string browser = browserName;
            string environment = env;
            string os = operatingSystem;
            string buildName = buldName;
            string version = vrsion;
            string testName = testCaseName;
            bool isLocalExecution = localRun;

            // Get from Configuration file
            //string userName = CommonMethods.Get_JsonAttribute("Configuration.json", "SauceLabsCredentials.User", isInputFile: false).ToString();
            //string accessKey = CommonMethods.Get_JsonAttribute("Configuration.json", "SauceLabsCredentials.AccessKey", isInputFile: false).ToString();
            //string parentTunnel = CommonMethods.Get_JsonAttribute("Configuration.json", "SauceLabsCredentials.ParentTunnel", isInputFile: false).ToString();
            //string remoteURL = CommonMethods.Get_JsonAttribute("Configuration.json", "SauceLabsCredentials.RemoteURL", isInputFile: false).ToString();
            //string proxyURL = CommonMethods.Get_JsonAttribute("Configuration.json", "SauceLabsCredentials.ProxyURL", isInputFile: false).ToString();
            string userName = string.Empty;
            string accessKey = string.Empty;
            string parentTunnel = string.Empty;
            string remoteURL = string.Empty;
            string proxyURL = string.Empty;
            #endregion

            IWebDriver driver;
            HttpCommandExecutor executor = new HttpCommandExecutor(new Uri(remoteURL), TimeSpan.FromSeconds(120), false)
            {
                Proxy = new WebProxy(new Uri(proxyURL))
            };

            switch (browser)
            {
                case "InternetExplorer":
                    if (isLocalExecution)
                    {
                        driver = new InternetExplorerDriver(Environment.CurrentDirectory, new InternetExplorerOptions(), TimeSpan.FromSeconds(300));
                        break;
                    }

                    InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                    ieOptions.AddAdditionalCapability("username", userName, true);
                    ieOptions.AddAdditionalCapability("accessKey", accessKey, true);
                    ieOptions.AddAdditionalCapability("parentTunnel", parentTunnel, true);
                    ieOptions.AddAdditionalCapability("platform", os, true);
                    ieOptions.AddAdditionalCapability("tunnelIdentifier", environment, true);
                    ieOptions.AddAdditionalCapability("name", testName, true);
                    ieOptions.AddAdditionalCapability("build", buildName, true);
                    ieOptions.AddAdditionalCapability("version", version, true);
                    driver = new RemoteWebDriver(executor, ieOptions.ToCapabilities());
                    break;

                case "Edge":
                    if (isLocalExecution)
                    {
                        driver = new EdgeDriver(Environment.CurrentDirectory, new EdgeOptions(), TimeSpan.FromSeconds(300));
                        break;
                    }

                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.AddAdditionalCapability("username", userName);
                    edgeOptions.AddAdditionalCapability("accessKey", accessKey);
                    edgeOptions.AddAdditionalCapability("parentTunnel", parentTunnel);
                    edgeOptions.AddAdditionalCapability("platform", os);
                    edgeOptions.AddAdditionalCapability("tunnelIdentifier", environment);
                    edgeOptions.AddAdditionalCapability("name", testName);
                    edgeOptions.AddAdditionalCapability("build", buildName);
                    edgeOptions.AddAdditionalCapability("version", version);
                    driver = new RemoteWebDriver(executor, edgeOptions.ToCapabilities());
                    break;

                case "Firefox":
                    if (isLocalExecution)
                    {
                        driver = new FirefoxDriver(Environment.CurrentDirectory, new FirefoxOptions(), TimeSpan.FromSeconds(300));
                        break;
                    }

                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddAdditionalCapability("username", userName, true);
                    firefoxOptions.AddAdditionalCapability("accessKey", accessKey, true);
                    firefoxOptions.AddAdditionalCapability("parentTunnel", parentTunnel, true);
                    firefoxOptions.AddAdditionalCapability("platform", os, true);
                    firefoxOptions.AddAdditionalCapability("tunnelIdentifier", environment, true);
                    firefoxOptions.AddAdditionalCapability("name", testName, true);
                    firefoxOptions.AddAdditionalCapability("build", buildName, true);
                    firefoxOptions.AddAdditionalCapability("version", version, true);
                    driver = new RemoteWebDriver(executor, firefoxOptions.ToCapabilities());
                    break;

                default:
                    if (isLocalExecution)
                    {
                        //ChromeOptions chromeOptions1 = new ChromeOptions();
                        //chromeOptions1.EnableMobileEmulation("Galaxy S5");
                        //driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions1, TimeSpan.FromSeconds(300));
                        driver = new ChromeDriver(Environment.CurrentDirectory, new ChromeOptions(), TimeSpan.FromSeconds(300));
                        break;
                    }

                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddAdditionalCapability("username", userName, true);
                    chromeOptions.AddAdditionalCapability("accessKey", accessKey, true);
                    chromeOptions.AddAdditionalCapability("parentTunnel", parentTunnel, true);
                    chromeOptions.AddAdditionalCapability("platform", os, true);
                    chromeOptions.AddAdditionalCapability("tunnelIdentifier", environment, true);
                    chromeOptions.AddAdditionalCapability("name", testName, true);
                    chromeOptions.AddAdditionalCapability("build", buildName, true);
                    chromeOptions.AddAdditionalCapability("version", version, true);
                    driver = new RemoteWebDriver(executor, chromeOptions.ToCapabilities());
                    break;
            }

            driver.Manage().Window.Maximize();
            return driver;
        }

    }
}

