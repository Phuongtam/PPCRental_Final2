using System;
using System.Collections.Generic;
using PPC.Models;
using FluentAssertions;


namespace PPC.AcceptanceTests.Support
{
    public class ReferenceUserList : Dictionary<string, USER>
    {
        public USER GetbyID(string usID)
        {
            return this[usID.Trim()].Should().NotBeNull()
                .And.Subject.Should().BeOfType<USER>().Which;
        }
    }
}
