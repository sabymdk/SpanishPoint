using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine;
using NUnit.Framework.Internal;
using SpanishPointAssessment.Drivers;
using SpanishPointAssessment.Pages;
using TechTalk.SpecFlow;
using NLog;
using Logger = NLog.Logger;

namespace SpanishPointAssessment.StepDefination
{
    [Binding]
   public class BaseStepDefination
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly WebDriverManager webDriverManager;
        private readonly HomePage homePage;
        private readonly RepertoireManagementPage repertoireManagementPage;

        public BaseStepDefination()
        {
            webDriverManager = new WebDriverManager();
            homePage = new HomePage(webDriverManager.Driver);
            repertoireManagementPage = new RepertoireManagementPage(webDriverManager.Driver);
        }

       [AfterScenario]
        public void TearDown()
        {
            Logger.Info("Tearing Down WebDriver after scenario execution");
            webDriverManager.Quit();
        }

        [Given("Navigate to the Matching Engine Website")]
        public void GivenNavigateToTheMatchingEngineWebsite()
        {
            Logger.Info("Navigating to Matching Engine Webiste");
            webDriverManager.Driver.Navigate().GoToUrl("https://www.matchingengine.com/");
            Thread.Sleep(2000);
        }

        [When("Navigate to the Repertoire Managment Module Page")]
        public void WhenNavigateToTheRepertoireManagmentModulePage()
        {
            Logger.Info("Navigating to Repertoire Management Module Page");
            homePage.HoverOverModules();
            homePage.ClickRepertoireModule();
            Thread.Sleep(2000);
        }

        [When("Check the supported products under Additional Features")]
        public void WhenCheckTheSupportedProductsUnderAdditionalFeatures()
        {
            Logger.Info("Checking supported products under Additional Features");
            repertoireManagementPage.ScrolltoAdditionalFeatures();
            repertoireManagementPage.ClickProductSupported();
            Thread.Sleep(2000);
        }

        [Then("Check the list of supported products displayed")]
        public void ThenCheckTheListOfSupportedProductsDisplayed()
        {
            Logger.Info("Verifying supported products list");
            Assert.IsTrue(repertoireManagementPage.IsSupportedProductsHeaderDisplayed(), "Supported products header is not displayed");
            Assert.IsTrue(repertoireManagementPage.AreProductsListed(), "No supported products found in the list");
            Thread.Sleep(2000);
        }

        [Then("Verify (.*) is available")]
        public void ThenVerifyIsAvailable(string expectedValue)
        {
            Logger.Info("Verifying the Product Supported Details");
            Assert.IsTrue(repertoireManagementPage.IsPrdouctSupportedDetailsDisplayed(expectedValue),"Supported product detail is not displayed");
            Thread.Sleep(2000);
        }



    }
}
