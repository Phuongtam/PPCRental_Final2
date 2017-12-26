using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC.Models;
using FluentAssertions;

namespace PPC.AcceptanceTests
{
    public class PropertyAssertions
    {
        public static void FoundPropertyName(IEnumerable<PROPERTY> foundProperty,IEnumerable<string> expectedTitles)
        {
            foundProperty.Select(x => x.PropertyName).Should().Contain(expectedTitles);
        }
        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> showProperty, string expectedTitle)
        {
            showProperty.Select(b => b.PropertyName).Should().Contain(expectedTitle);
        }

        //public static void HomeScreenShouldShow(IEnumerable<PROPERTY> ShownName, TechTalk.SpecFlow.Table expectednameList)
        //{
        //    throw new NotImplementedException();
        //}


        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> shownProperty, IEnumerable<string> expectedTitles)
        {
            shownProperty.Select(b => b.PropertyName).Should().Contain(expectedTitles);
        }
        public static void HomeScreenShouldShowInOrder(IEnumerable<PROPERTY> showProperty, IEnumerable<string> expectedTitles)
        {
            showProperty.Select(b => b.PropertyName).Should().Equal(expectedTitles);
        }

    }
}
