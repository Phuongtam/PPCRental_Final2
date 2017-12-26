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
    public sealed class TC3_ViewListOfProjectSteps
    {
        IWebDriver driver;
        [Given(@"I have enter the homepage")]
        public void GivenIHaveEnterTheHomepage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:51872/Home/Index");

        }

        [Given(@"I have click login")]
        public void GivenIHaveClickLogin()
        {
            driver.FindElement(By.Id("loginLink")).Click();
        }

        [When(@"I entered username and password")]
        public void WhenIEnteredUsernameAndPassword()
        {
            driver.FindElement(By.Id("Email")).SendKeys("lythihuyenchau@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("123456");

        }

        [When(@"click submit")]
        public void WhenClickSubmit()
        {
            driver.FindElement(By.ClassName("login-btn")).Click();
        }

        [Then(@"the result should show the list of project on the screen")]
        public void ThenTheResultShouldShowTheListOfProjectOnTheScreen()
        {
            Assert.AreEqual(true, driver.FindElement(By.ClassName("card-body")).Displayed);
            driver.Close();
        }

    }
}
