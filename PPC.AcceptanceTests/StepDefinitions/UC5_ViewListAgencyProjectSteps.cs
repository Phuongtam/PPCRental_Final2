using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using PPC.Models;
using PPC.AcceptanceTests.Drivers;

namespace PPC.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "automated4")]
    public class UC5_ViewListAgencyProjectSteps
    {
        private readonly SaleDriver _context;
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();

        public UC5_ViewListAgencyProjectSteps(SaleDriver driver)
        {
            _context = driver;

        }
        [When(@"I input '(.*)' and '(.*)' into Login page")]
        public void WhenIInputAndIntoLoginPage(string email, int pass)
        {
            _context.SaleLogin(email, pass.ToString());
        }

        [Then(@"I should show all agency project")]
        public void ThenIShouldShowAllAgencyProject(Table expected)
        {
            _context.ShowListOfAgencyProject(expected);
        }

    }
}
