using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PPC.Controllers;
using PPC.Models;
using PPC.AcceptanceTests.Support;
using PPC.AcceptanceTests.Common;
using TechTalk.SpecFlow;

namespace PPC.AcceptanceTests.Drivers
{
    public class SearchDriver
    {
        /*       private ActionResult _result;

               public SearchDriver(ActionResult result)
               {
                   _result = result;
               }
        */
        private readonly SearchResultState _state;

        public SearchDriver(SearchResultState state)
        {
            _state = state;
        }

        public void Search(string text, int? type, int? dis)
        {
            var controller = new HomeController();
            _state.ActionResult = controller.Search(text,type,dis);
        }

        public void ShowProperty(string expectedTitlesString)
        {
            //Arrange
            var expectedTitles = from t in expectedTitlesString.Split(',')
                                    select t.Trim().Trim('\'');
            //Action
            var ShowProperty = _state.ActionResult.Model<IEnumerable<PROPERTY>>();

            //Assert
            PropertyAssertions.HomeScreenShouldShow(ShowProperty, expectedTitles);
        }

        public void ShowProperty(Table expectedProject)
        {
            //Arrange
            var expectedTitles = expectedProject.Rows.Select(r => r["Title"]);

            //Action
            var ShowProperty = _state.ActionResult.Model<IEnumerable<PROPERTY>>();

            //Assert
            PropertyAssertions.HomeScreenShouldShowInOrder(ShowProperty, expectedTitles);
        }
    }
}
