using System.Collections.Generic;
using PPC.Models;
using FluentAssertions;

namespace PPCProject.AcceptanceTests.Support
{
    public class ReferenceProjectList : Dictionary<string, PROPERTY>
    {
        public PROPERTY GetById(string projectId)
        {
            return this[projectId.Trim()].Should().NotBeNull()
                                      .And.Subject.Should().BeOfType<PROPERTY>().Which;
        }
    }
}
