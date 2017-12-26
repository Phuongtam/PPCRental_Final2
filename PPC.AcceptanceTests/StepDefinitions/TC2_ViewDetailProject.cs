using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace PPC.AcceptanceTests.StepDefinitions
{
    [Binding]
    public sealed class TC2_ViewDetailProject
    {
        IWebDriver driver;
        [Given(@"I have entered into the homepage")]
        public void GivenIHaveEnteredIntoTheHomepage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:51872/Home/Index");
            Thread.Sleep(1000);
        }

        [When(@"I press view detail")]
        public void WhenIPressViewDetail()
        {

            driver.FindElement(By.Id("btn-1")).Click();
            Thread.Sleep(1000);

        }

        [Then(@"the result should show the detail of project on the screen")]
        public void ThenTheResultShouldShowTheDetailOfProjectOnTheScreen()
        {
            Assert.AreEqual(true, driver.FindElement(By.ClassName("row")).Displayed);
            Thread.Sleep(1000);
            driver.Close();
        }

    }
}
