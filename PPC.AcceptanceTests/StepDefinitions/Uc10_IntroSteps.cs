using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPC.Models;

namespace PPC.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class Uc10_IntroSteps
    {
        IWebDriver driver;
        [Given(@"I am as a Home Page")]
        public void GivenIAmAsAHomePage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:51872/Home/Index");
        }
        
        [When(@"I click on about")]
        public void WhenIClickOnAbout()
        {
            driver.FindElement(By.Id("about")).Click();
        }
        
        [Then(@"show introduction about company ppc rental")]
        public void ThenShowIntroductionAboutCompanyPpcRental(string p0)
        {
            var expectedContent = p0.Split(',').Select(t => t.Trim().Trim('\''));
            driver.SwitchTo().DefaultContent();

            string descriptionTextPath = "//table/tbody/tr";
            var viewintro = from row in driver.FindElements(By.XPath(descriptionTextPath))
                               let content = row.FindElement(By.Id("pName")).Text
                               select new INTRODUCTION { Content = content };
            Intro.FoundContent(viewintro, expectedContent);
            driver.Close();
        }
    }
}
