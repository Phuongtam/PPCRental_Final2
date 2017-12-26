using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC.Models;

namespace PPC.Controllers
{
    public class HomeController : Controller
    {
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();
     // List<SelectListItem> type, district;
        public ActionResult Index()
        {

           
            var product = db.PROPERTY.Where(d => d.Status_ID == 3).ToList();
            return View(product);

        }
        public JsonResult GetStreet(int District_id)
        {
            return Json(
            db.STREET.Where(s => s.District_ID == District_id)
            .Select(s => new { id = s.ID, text = s.StreetName }).ToList(),
            JsonRequestBehavior.AllowGet);
        }
        //
        //
       
        [HttpGet]
        public ActionResult Search(string txtSearch,int? PropertyType_ID,int? District_ID)
        {
            var project = db.PROPERTY.Where(x => x.Status_ID == 3).ToList();
            if (PropertyType_ID != null && District_ID != null)
            {
                project = project.Where(x => (x.PropertyName.Contains(txtSearch)) && (x.District_ID == District_ID) || (x.PropertyType_ID == PropertyType_ID)).ToList();
            }
            else
            {
                if (PropertyType_ID == null && District_ID != null)
                {
                    project = project.Where(x => (x.PropertyName.Contains(txtSearch)) && (x.District_ID == District_ID)).ToList();

                }
                else if (District_ID == null && PropertyType_ID != null)
                {
                    project = project.Where(x => (x.PropertyName.Contains(txtSearch)) && (x.PropertyType_ID == PropertyType_ID)).ToList();

                }
                else
                {
                    project = project.Where(x => x.PropertyName.Contains(txtSearch)).ToList();

                }
            }

            return View(project);
        }
       
        public ActionResult About()
        {
            var ab = db.INTRODUCTION.ToList();

            return View(ab);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}