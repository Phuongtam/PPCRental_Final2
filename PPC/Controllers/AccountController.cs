using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PPC.Models;

namespace PPC.Controllers
{
    public class AccountController : Controller
    {
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = db.USER.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    Session["UserRole"] = user.Role.ToString();
                    Session["UserIDs"] = user.UserType_ID;
                    Session["Fullname"] = user.FullName;
                    Session["UserID"] = user.ID;
                    if (Session["UserRole"].ToString() == "2")
                    {
                        return RedirectToAction("ViewListMyProject", "AgencyProperty");
                    }
                    return RedirectToAction("ViewListofAgencyProject", "Admin/ProjectAdmin");
                    //Session["FullName"] = user.FullName;
                    //Session["UserID"] = user.ID;
                    //Session["RoleID"] = user.Role;

                    //if (int.Parse(Session["RoleID"].ToString()) == 1)
                    //{
                    //    return RedirectToAction("Index");
                    //}
                    //else
                    //{
                    //    return RedirectToAction("Index", "ProductAdmin", new { area = "Admin" });
                    //}
                }
            }
            else
            {
                ViewBag.mess = "* Account Invalid";
            }
            return View();
        }
        public ActionResult Logout()
        {
            var user = db.USER;
            if (user != null)
            {
                Session["FullName"] = null;
                Session["UserID"] = null;
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Register
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email already is exists");
                }
                else
                {
                    var user = new USER();
                    user.FullName = model.FullName;
                    user.Email = model.Email;
                    user.Password = model.Password;
                    //user.Phone = model.Phone;
                    //user.Address = model.Address;
                    user.Role = 2;
                    user.Status = true;
                    var result = Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Register is successfull";
                        model = new RegisterViewModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Register is false");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public bool CheckEmail(string email)
        {
            return db.USER.Count(x => x.Email == email) > 0;
        }
        public long Insert(USER entity)
        {
            db.USER.Add(entity);
            db.SaveChanges();
            return entity.ID;


        }

    }
}