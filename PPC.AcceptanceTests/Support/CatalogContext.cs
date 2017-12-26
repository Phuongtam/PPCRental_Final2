using PPCProject.AcceptanceTests.Support;

namespace PPC.AcceptanceTests.Support
{
    public class CatalogContext
    {
        public CatalogContext()
        {
            ReferenceBooks = new ReferenceProjectList();
        }

        public ReferenceProjectList ReferenceBooks { get; set; }
    }
}
