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
    class HomePage
    {
        private readonly IWebDriver driver;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ModulesMenu => driver.FindElement(By.XPath("//a[contains(text(),'Modules')]"));
        private IWebElement RepertoireModule => driver.FindElement(By.XPath("//a[contains(text(),'Repertoire Management Module')]"));

        public void HoverOverModules()
        {
            Logger.Info("Hovering over Modules Menu");
            Actions actions = new Actions(driver);
            actions.MoveToElement(ModulesMenu).Perform();
        }

        public void ClickRepertoireModule()
        {
            Logger.Info("Clicking on Repertoire Management Module");
            RepertoireModule.Click();
        }
    }
}
