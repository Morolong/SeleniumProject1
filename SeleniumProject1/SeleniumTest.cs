using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace SeleniumProject1
{
    public class Tests
    {
       IWebDriver driver; 

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(options); 
        }

        [Test]
        public void verifyLogo()
        {
            driver.Navigate().GoToUrl("https://www.browserstack.com/");

            var elements = driver.FindElements(By.Id("logo"));
            Assert.That(
                elements.Count > 0 && elements[0].Displayed, "Logo element not found or not diplayed.");

        }

        [Test]
        public void verifyMenuItemcount()
        {
            ReadOnlyCollection<IWebElement> menuItem = driver.FindElements(By.XPath("//ul[contains(@class,'horizontal-list product-menu')]/li"));

            Assert.That(menuItem.Count, Is.EqualTo(4));
        }

        [Test]

        public void verifyPricingPage()

        {
            driver.Navigate().GoToUrl("https://browserstack.com/pricing");

            IWebElement contactUsPageheader = driver.FindElement(By.TagName("h1"));

            Assert.That(contactUsPageheader.Text.Contains("Real device cloud of 30,000+ real iOS & Android devices, instantly accessible")); 
            
        }

        [OneTimeTearDown]

        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
