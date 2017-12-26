using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC.AcceptanceTests.Support;

namespace PPC.AcceptanceTests.Support
{
    public class CatalogContextU
    {
        public CatalogContextU()
        {
            ReferenceUsers = new ReferenceUserList();
        }
        public ReferenceUserList ReferenceUsers { get; set; }

    }
}
