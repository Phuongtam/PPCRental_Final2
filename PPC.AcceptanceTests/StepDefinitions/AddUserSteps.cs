using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PPC.Models;
using System.Linq;
using PPC.AcceptanceTests.Drivers;
using PPC.AcceptanceTests.Drivers.User;

namespace PPC.AcceptanceTests.StepDefinitions

{
    [Binding]
  public  class AddUserSteps
    {
        private readonly UserDriver _userDriver;
        public AddUserSteps(UserDriver driver)
        {
            _userDriver = driver;
        }
        [Given(@"user table :")]
        public void GivenUserTable(Table table)
        {
            _userDriver.InsertToDb(table);
        }


    }
}
