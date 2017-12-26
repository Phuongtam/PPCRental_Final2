using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PPC.Models;
using PPC.Controllers;
using TechTalk.SpecFlow;
using PPC.AcceptanceTests.Common;
using PPC.AcceptanceTests.Support;
using PPC.AcceptanceTests;
using PPC.AcceptanceTests.Drivers;
using FluentAssertions;
using System.Web.Routing;
using PPC.Areas.Admin.Controllers;
namespace PPC.AcceptanceTests.Drivers
{
    public class SaleDriver
    {
        private ActionResult _context;
        public void SaleLogin(string email, string password)
        {
            var routeData = new RouteData();
            routeData.Values.Add("action", "ViewListofAgencyProject");
            routeData.Values.Add("controller", "ProjectAdmin");

            var accountController = GetAcountController(routeData);

            _context = accountController.Login(email, password);

            if (((RedirectToRouteResult)_context).RouteValues["action"].Equals("ViewListofAgencyProject"))
            {
                var propertyController = GetSaleController();

                _context = propertyController.ViewListofAgencyProject();

                var shownProperties = _context.Model<IEnumerable<PROPERTY>>();
                ScenarioContext.Current.Add("Property", shownProperties);
            }
        }
        private static ProjectAdminController GetSaleController()
        {
            var controller = new ProjectAdminController();
            HttpContextStub.SetupController(controller);
            return controller;
        }
        private static AccountController GetAcountController(RouteData routedata)
        {
            var controller = new AccountController();
            HttpContextStub.SetupController(controller, routedata);
            return controller;
        }
        public void ShowListOfAgencyProject(Table showProject)
        {
            //Arrange
            var expectedProjects = showProject.Rows.Select(r => r["PropertyName"]);

            //Action
            var result = ScenarioContext.Current.Get<IEnumerable<PROPERTY>>("Property");
            //var actualProjects = result.Model<IEnumerable<PROPERTY>>();

            //Assert
            PropertyAssertions.HomeScreenShouldShowInOrder(result, expectedProjects);
        }
    }
}
