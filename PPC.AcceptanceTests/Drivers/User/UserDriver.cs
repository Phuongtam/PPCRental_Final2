using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC.Models;
using PPC.AcceptanceTests.Support;
using PPC.Controllers;
using FluentAssertions;
using TechTalk.SpecFlow;
using System.Web.Mvc;
using PPC.Areas.Admin.Controllers;
using System.Web;

namespace PPC.AcceptanceTests.Drivers.User
{
    public class UserDriver
    {
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();
        private readonly CatalogContextU _context;
        private ActionResult _result;
        public AccountController user;
        public USER us;

        public UserDriver(CatalogContextU context)
        {
            _context = context;
        }
        public void Navigate()
        {
            using (var controller = new AccountController())
            {
                _result = controller.Login();
            }
        }
        public void InsertToDb(Table us)
        {
            using (db)
            {

                foreach (var row in us.Rows)
                {


                    var user = new USER
                    {
                        Email = row["Email"],
                        Password = row["Password"],
                        FullName = row["FullName"],
                        Phone = row["Phone"],
                        Address = row["Address"],
                        Role = int.Parse(row["Role"]),
                        Status = true,
                    };
                    _context.ReferenceUsers.Add(us.Header.Contains("ID") ? row["ID"] : user.Email, user);

                    db.USER.Add(user);
                }

                db.SaveChanges();
            }
        }
        public void Login(string email, string pwd)
        {
            user = new AccountController();
            db = new DemoPPCRentalEntities();
            us = db.USER.FirstOrDefault(d => d.Email == email);

            var moqContext = new Moq.Mock<ControllerContext>();
            var moqSession = new Moq.Mock<HttpSessionStateBase>();
            moqContext.Setup(c => c.HttpContext.Session).Returns(moqSession.Object);
            user.ControllerContext = moqContext.Object;
            moqSession.Setup(s => s["UserRole"]).Returns("2");//debug

            us.Email = email;
            us.Password = pwd;
            us.Role = db.USER.FirstOrDefault(d => d.Email == email).Role;
            us.Phone = db.USER.FirstOrDefault(d => d.Email == email).Phone;
            us.Address = db.USER.FirstOrDefault(d => d.Email == email).Address;
            us.Role = db.USER.FirstOrDefault(d => d.Email == email).Role;
            us.ID = db.USER.FirstOrDefault(d => d.Email == email).ID;
            us.Status = db.USER.FirstOrDefault(d => d.Email == email).Status;
            us.FullName = db.USER.FirstOrDefault(d => d.Email == email).FullName;
            user.Login(email, pwd);
        }


    }
}
