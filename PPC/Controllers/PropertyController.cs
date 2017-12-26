using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPC.Models;
namespace PPC.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROPERTY property = db.PROPERTY.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }
    }
}