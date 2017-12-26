using PPC.AcceptanceTests.Drivers.User;
using PPC.AcceptanceTests.Support;
using System;
using TechTalk.SpecFlow;

namespace PPC.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "login")]
    public class LoginSteps
    {
        private readonly UserDriver _userDriver;
        public LoginSteps(UserDriver driver)
        {
            _userDriver = driver;
        }

        [When(@"I am at Home Page")]
        public void WhenIAmAtHomePage()
        {
            _userDriver.Navigate();
        }

        [When(@"I have navigate to Login Page")]
        public void WhenIHaveNavigateToLoginPage()
        {
            _userDriver.Navigate();
        }

        [When(@"I entered '(.*)' and '(.*)'")]
        public void WhenIEnteredAnd(string email, string password)
        {
            _userDriver.Login(email, password);
        }

    }
}
