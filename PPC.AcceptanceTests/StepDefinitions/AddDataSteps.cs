using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PPC.Models;
using System.Linq;
using PPC.AcceptanceTests.Drivers;

namespace PPC.AcceptanceTests.StepDefinitions
{
    [Binding]
   public class Steps
    {
        private readonly ProjectDriver _projectDriver;
        public Steps(ProjectDriver driver)
        {
            _projectDriver = driver;
        }

        
        [Given(@"the following project")]
        public void GivenTheFollowingProject(Table givenProjects)
        {
            _projectDriver.InsertProjecttoDB(givenProjects);
        }
        

    }
}
