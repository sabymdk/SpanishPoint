using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;


namespace SpanishPointAssessment.Drivers
{
    
    class WebDriverManager
    {

        public IWebDriver Driver { get; set; }

        public WebDriverManager()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();

        }

        [AfterScenario]
        public void Quit()
        {
            Driver.Quit();
        }


        
    }
}
