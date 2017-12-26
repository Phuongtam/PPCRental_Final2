using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC.Models;
using PPC.AcceptanceTests.Drivers;
using TechTalk.SpecFlow;

namespace PPC.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "automated3")]
    public  class UC3_ViewDetailSteps
    {
        private readonly ProjectDriver _context;
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();
        public UC3_ViewDetailSteps(ProjectDriver driver)
        {
            _context = driver;

        }
        [When(@"I press the button Detail in project '(.*)'")]
        public void WhenIPressTheButtonDetailInProject(string name)
        {
            int id = db.PROPERTY.ToList().FirstOrDefault(x => x.PropertyName == name).ID;
            _context.Details(id);
        }

        [Then(@"the result should show :")]
        public void ThenTheResultShouldShow(Table table)
        {
            _context.ShowPropertyDetails(table);
        }


    }
}
