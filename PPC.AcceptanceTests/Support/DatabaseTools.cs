using PPC.Models;
using TechTalk.SpecFlow;

namespace PPC.AcceptanceTests.Support
{
    [Binding]
    public class DatabaseTools
    {
        [BeforeScenario]
        public void CleanDatabase()
        {
            using (var db = new DemoPPCRentalEntities())
            {
                //db.OrderLines.RemoveRange(db.OrderLines);
                db.INTRODUCTION.RemoveRange(db.INTRODUCTION);
                db.PROPERTY.RemoveRange(db.PROPERTY);
                db.SaveChanges();
            }
        }
    }
}
