using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPC.Models;
using PPC.AcceptanceTests.Drivers;


namespace PPC.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "@automation2")]

    public class UC2_ViewListOfProjectSteps
    {
        private readonly ProjectDriver _context;
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();

        public UC2_ViewListOfProjectSteps(ProjectDriver driver)
        {
            _context = driver;

        }
        [When(@"I input '(.*)' and '(.*)' into Login page")]
        public void WhenIInputAndIntoLoginPage(string email, int pass)
        {
            _context.Login(email, pass.ToString());
        }

        [Then(@"I should see my own projects")]
        public void ThenIShouldSeeMyOwnProjects(Table expected)
        {
            _context.ShowListOfProject(expected);
        }
        

    }
}
