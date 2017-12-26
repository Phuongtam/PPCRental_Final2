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


namespace PPC.AcceptanceTests.Drivers

{
    public class ProjectDriver
    {
        //private readonly SearchResultState _context;
        private ActionResult _context;

        //public ProjectDriver(SearchResultState context)
        //{
        //    _context = context;
        //}

        public void InsertProjecttoDB(Table givenProjects)
        {
            using (var db = new DemoPPCRentalEntities())
            {
                foreach (var row in givenProjects.Rows)
                {
                    var property = new PROPERTY
                    {
                        PropertyName = row["PropertyName"],
                        PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(x => x.CodeType == row["PropertyType"]).ID,
                        Status_ID = db.PROJECT_STATUS.ToList().FirstOrDefault(x => x.Status_Name == row["Status"]).ID,
                        District_ID = db.DISTRICT.ToList().FirstOrDefault(x => x.DistrictName == row["District"]).ID,
                        Street_ID = db.STREET.ToList().FirstOrDefault(x => x.StreetName == row["Street"]).ID,
                        Content = row["Content"],
                        UserID = db.USER.ToList().FirstOrDefault(x => x.FullName == row["Agency"]).ID,
                        Sale_ID = db.USER.ToList().FirstOrDefault(x => x.FullName == row["Sale"]).ID,
                        Avatar = row["Avarta"],
                        Images = row["Images"],
                        BedRoom = int.Parse(row["BedRoom"]),
                        BathRoom = int.Parse(row["BathRoom"]),
                        PackingPlace = int.Parse(row["PackingPlace"]),
                        Price = int.Parse(row["Price"]),
                         Area = row["Area"],
                    };

                    //_context.ReferenceBooks.Add(
                    //        givenProjects.Header.Contains("ID") ? row["ID"] : row["PropertyName"],
                    //        property);

                    db.PROPERTY.Add(property);
                }

                db.SaveChanges();
            }
        }
        //public void insertIntro(Table givenProjects)
        //{
        //    using (var db = new DemoPPCRentalEntities())
        //    {
        //        foreach (var row in givenProjects.Rows)
        //        {
        //            var about = new INTRODUCTION
        //            {
        //                Content = row["Content"],
        //               // create_user = db.USER.ToList().FirstOrDefault(x => x.Email == row["create_user"]).ID,
        //                image = row["image"],


        //            };

        //            //_context.ReferenceBooks.Add(
        //            //        givenProjects.Header.Contains("ID") ? row["ID"] : row["PropertyName"],
        //            //        property);

        //            db.INTRODUCTION.Add(about);
        //        }

        //        db.SaveChanges();
        //    }
        //}
        public void Login(string email, string password)
        {
            var routeData = new RouteData();
            routeData.Values.Add("action", "ViewListMyProject");
            routeData.Values.Add("controller", "AgencyProperty");

            var accountController = GetAcountController(routeData);

            _context = accountController.Login(email, password);

            if (((RedirectToRouteResult)_context).RouteValues["action"].Equals("ViewListMyProject"))
            {
                var propertyController = GetAgencyPropertyController();

                _context = propertyController.ViewListMyProject();

                var shownProperties = _context.Model<IEnumerable<PROPERTY>>();
                ScenarioContext.Current.Add("Property", shownProperties);
            }
        }
        private static AgencyPropertyController GetAgencyPropertyController()
        {
            var controller = new AgencyPropertyController();
            HttpContextStub.SetupController(controller);
            return controller;
        }
        private static AccountController GetAcountController(RouteData routedata)
        {
            var controller = new AccountController();
            HttpContextStub.SetupController(controller, routedata);
            return controller;
        }
        public void ShowListOfProject(Table showProject)
        {
            //Arrange
            var expectedProjects = showProject.Rows.Select(r => r["PropertyName"]);

            //Action
            var result = ScenarioContext.Current.Get<IEnumerable<PROPERTY>>("Property");
            //var actualProjects = result.Model<IEnumerable<PROPERTY>>();

            //Assert
            PropertyAssertions.HomeScreenShouldShow(result, expectedProjects);
        }

        //public void Login(string email, string pass)
        //{
        //    using (var controller = new AccountController())
        //    {
        //        _context = controller.Login(email, pass);
        //    }
        //}


     
        public void ViewDetail(string propertyName)
        {
            var db = new DemoPPCRentalEntities();

            int id = db.PROPERTY.FirstOrDefault(r => r.PropertyName == propertyName).ID;

            using (var controller = new PropertyController())
            {
                _context = controller.Details(id);
            }
        }


        public void ShowList(Table expectednameList)
        {
            //Arrange
            var expected = expectednameList.Rows.Select(x => x["PropertyName"]);
            //Action
            var ShownName = _context.Model<IEnumerable<PROPERTY>>();

            //Assert
            PropertyAssertions.HomeScreenShouldShow(ShownName, expected);
        }
        
        public void ShowPropertyDetails(Table shownPropertyDetails)
        {
            DemoPPCRentalEntities db = new DemoPPCRentalEntities();
            //Arrange
            var expectedPropertyDetails = shownPropertyDetails.Rows.Single();
        
            //Act
            var actualPropertyDetails = _context.Model<PROPERTY>();

            //Assert
            actualPropertyDetails.Should().Match<PROPERTY>(
                b => (b.PropertyName == expectedPropertyDetails["PropertyName"])) ;
        }

        public void Details(int Id)
        {
            var controller = new PropertyController();
            _context = controller.Details(Id);
        }
       

    }
}
