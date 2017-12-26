using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PPC.Models;
using System.Linq;
using PPC.AcceptanceTests.Drivers;

namespace PPC.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "automated")]
    public class ProjectFilterSteps
    {

        private readonly SearchDriver _searchDriver;
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();

        public ProjectFilterSteps(SearchDriver driver)
        {
            _searchDriver = driver;

        }
        [When(@"I search for projects by the phrase '(.*)','(.*)','(.*)'")]
        public void WhenISearchForProjectsByThePhrase(string p0, string p1, string p2)
        {

            int type_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(x => x.CodeType == p1).ID;
            int Dis_ID = db.DISTRICT.ToList().FirstOrDefault(x => x.DistrictName == p2).ID;
            _searchDriver.Search(p0, type_ID, Dis_ID);
        }




        [Then(@"project should display project with projectname follow '(.*)'")]
        public void ThenProjectShouldDisplayProjectWithProjectnameFollow(string expectedTitles)
        {
            _searchDriver.ShowProperty(expectedTitles);
        }




    }
}
