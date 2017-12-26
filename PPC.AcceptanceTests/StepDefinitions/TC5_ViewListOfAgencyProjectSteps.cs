using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PPC.AcceptanceTests.StepDefinitions
{
    [Binding]
    public sealed class TC5_ViewListOfAgencyProjectSteps
    {
        IWebDriver driver;
        [When(@"I entert he url")]
        public void WhenIEntertHeUrl()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:51872/Admin/ProjectAdmin/Index");
        }

        [Then(@"the result should show the list of agency project on the screen")]
        public void ThenTheResultShouldShowTheListOfAgencyProjectOnTheScreen()
        {
            Assert.AreEqual(true, driver.FindElement(By.Id("dataTable_wrapper")).Displayed);
            driver.Close();
        }

    }
}
