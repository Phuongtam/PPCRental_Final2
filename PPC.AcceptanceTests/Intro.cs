using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC.Models;
using FluentAssertions;

namespace PPC.AcceptanceTests
{
    public class Intro
    {
        public static void FoundContent(IEnumerable<INTRODUCTION> foundProperty, IEnumerable<string> expectedTitles)
        {
            foundProperty.Select(x => x.Content).Should().Contain(expectedTitles);
        }
    }
}
