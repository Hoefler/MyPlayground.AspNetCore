using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace MyPlayground.UiTests
{
    [TestFixture("http://localhost/RazorPages")]
    public class SeleniumTests
    {
        private static bool headless = false;

        private static RemoteWebDriver[] webDrivers;

        public static RemoteWebDriver[] WebDrivers
        {
            get
            {
                if (webDrivers == null)
                {
                    var chromeOptions = new ChromeOptions();
                    var firefoxOptions = new FirefoxOptions();

                    if (headless)
                    {
                        chromeOptions.AddArgument("headless");
                        firefoxOptions.AddArgument("--headless");
                    }

                    webDrivers = new List<RemoteWebDriver>()
                    {
                        new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, chromeOptions),
                        //new FirefoxDriver(AppDomain.CurrentDomain.BaseDirectory, firefoxOptions),
                    }.ToArray();
                }

                return webDrivers;
            }
        }

        private readonly string url;

        public SeleniumTests(string url)
        {
            this.url = url;
        }

        [SetUp]
        public void Setup()
        {
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var webDriver in WebDrivers)
            {
                webDriver.Close();
                webDriver.Dispose();
            }
        }

        [Test, TestCaseSource(nameof(WebDrivers))]
        public void Navigate_Test_MobileDevice(RemoteWebDriver driver)
        {
            var oldSize = driver.Manage().Window.Size;
            driver.Manage().Window.Size = new Size(400,600);
            Thread.Sleep(5000);
            Navigate_Test(driver);
            driver.Manage().Window.Size = oldSize;

        }

        [Test, TestCaseSource(nameof(WebDrivers))]
        public void Navigate_Test(RemoteWebDriver driver)
        {
            driver.Navigate().GoToUrl(this.url);

            driver.FindElementByLinkText("Privacy").Click();

            Thread.Sleep(5000);

            new WebDriverWait(driver, TimeSpan.FromSeconds(1)).Until(d => d.FindElement(By.TagName("h1")).Displayed);

            Assert.AreEqual("Privacy Policy", driver.FindElementByTagName("h1").Text);
            
            driver.FindElementByLinkText("Home").Click();

            Thread.Sleep(5000);

            Assert.AreEqual("Welcome", driver.FindElementByTagName("h1").Text);

            var radioButtons = driver.FindElementsByTagName("input");
            Assert.AreEqual(4, radioButtons.Count);
            foreach (var element in radioButtons)
            {
                var isChecked = Convert.ToBoolean(element.GetAttribute("checked"));

                if (element.GetAttribute("value") == "telefonkarte")
                {
                    Assert.IsTrue(isChecked);
                }
                else
                {
                    Assert.IsFalse(isChecked);
                }
            }
        }

        [Test, TestCaseSource(nameof(WebDrivers))]
        public void RadioButton_Test(RemoteWebDriver driver)
        {
            driver.Navigate().GoToUrl(this.url);

            var radioButtons = driver.FindElementsByTagName("input");
            Assert.AreEqual(4, radioButtons.Count);
            foreach (var element in radioButtons)
            {
                var isChecked = Convert.ToBoolean(element.GetAttribute("checked"));

                if (element.GetAttribute("value") == "telefonkarte")
                {
                    Assert.IsTrue(isChecked);
                }
                else
                {
                    Assert.IsFalse(isChecked);
                }
            }
        }

        [Test, TestCaseSource(nameof(WebDrivers))]
        public void Button_Click_Test(RemoteWebDriver driver)
        {
            driver.Navigate().GoToUrl(this.url);

            var radioButtons = driver.FindElementsByTagName("input");
            radioButtons.Single(x => x.GetAttribute("id") == "paypal").Click();

            var button = driver.FindElementById("buttonBestellen");
            button.Click();

            Thread.Sleep(5000);

            var alert = driver.SwitchTo().Alert();
            var text = alert.Text;
            alert.Accept();

            Assert.AreEqual("Mit 'paypal' bestellt.", text);
        }

        [Test, TestCaseSource(nameof(WebDrivers))]
        public void Screenshot_Test(RemoteWebDriver driver)
        {
            driver.Navigate().GoToUrl(this.url);

            Screenshot ss = ((ITakesScreenshot) driver).GetScreenshot();

            //Use it as you want now
            var baseFileNamePng = $"../../../Screenshots/{driver.GetType()}_base.png";
            var baseFileNameTxt = baseFileNamePng + ".txt";

            // save base line
            /*ss.SaveAsFile(baseFileNamePng, ScreenshotImageFormat.Png);
            File.WriteAllText(baseFileNameTxt, ss.ToString());*/

            var BaseAsBase64EncodedString = File.ReadAllText(baseFileNameTxt);
            Assert.AreEqual(BaseAsBase64EncodedString, ss.ToString());
        }
    }
}