using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpanishPointAssessment.Pages
{
    class RepertoireManagementPage
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IWebDriver driver;
        public RepertoireManagementPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement AdditionalFeatures => driver.FindElement(By.XPath("//h2[contains(text(),'Additional Features')]"));
        private IWebElement ProductsSupported => driver.FindElement(By.XPath("//span[contains(text(),'Products Supported')]"));
        private IWebElement SupportedProductsHeader => driver.FindElement(By.XPath("//h3[contains(text(),'There are several types of Product Supported:')]"));
        private IWebElement ProductsSupportedDetailsRecording => driver.FindElement(By.XPath("//span[contains(text(),'Recording')]"));
        private IWebElement ProductsSupportedDetailsBundle => driver.FindElement(By.XPath("//span[contains(text(),'Bundle')]"));
        private IWebElement ProductsSupportedDetailsAdvertisement => driver.FindElement(By.XPath("//span[contains(text(),'Advertisement')]"));
        private IWebElement ProductsSupportedDetailsCueSheetAVWork => driver.FindElement(By.XPath("//span[contains(text(),'Cue Sheet / AV Work')]"));

        private IList<IWebElement> ProductsList => driver.FindElements(By.XPath("//ul/li"));

        public void ScrolltoAdditionalFeatures()
        {
            Logger.Info("Scrolling to Additional Features Section");
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", AdditionalFeatures);
        }

        public void ClickProductSupported()
        {
            Logger.Info("Clicking Products Supported button");
            ProductsSupported.Click();
        }

        public bool IsSupportedProductsHeaderDisplayed()
        {
            Logger.Info("Checking if Supported Products Header is Displayed");
            return SupportedProductsHeader.Displayed;
        }

        public bool AreProductsListed()
        {
            Logger.Info("Checking if supported products list is populated");
            return ProductsList.Count > 0;
        }

        public bool IsPrdouctSupportedDetailsDisplayed(string expectedValue)
        {
            Logger.Info("Checking if Product Details are Available");
            if(expectedValue == "'Cue Sheet / AV Work'")
                return ProductsSupportedDetailsCueSheetAVWork.Displayed;

            else if(expectedValue == "'Recording'")
                return ProductsSupportedDetailsRecording.Displayed;

            else if (expectedValue == "'Bundle'")
                return ProductsSupportedDetailsBundle.Displayed;

            else if (expectedValue == "'Advertisement'")
                return ProductsSupportedDetailsAdvertisement.Displayed;

            else
                return false;
        }

    }
}
