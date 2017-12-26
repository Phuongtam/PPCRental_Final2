using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC.Models;
using System.IO;

namespace PPC.Controllers
{
    public class AgencyPropertyController : Controller
    {
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();

        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
        }
        // GET: AgencyProperty
        public ActionResult ViewListMyProject()
        {
            if (Session["UserID"] != null)
            {
                var id = Session["UserID"];
                var user = db.USER.Find(id);
                var userid = user.ID;
                var product = db.PROPERTY.Where(d => d.UserID == userid).ToList();
                return View(product);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }

        }

        public ActionResult ViewDraftProject()
        {
            if (Session["UserID"] != null)
            {
                var id = Session["UserID"];
                var user = db.USER.Find(id);
                var userid = user.ID;

                var id2 = Session["Status_ID"];
                var project = db.PROJECT_STATUS.Find(id2 = 2);
                var projectid = project.ID;
                var product = db.PROPERTY.Where(d => d.Status_ID == projectid && d.UserID == userid).ToList();
                return View(product);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }

        }

        public ActionResult ViewPostedProject()
        {
            if (Session["UserID"] != null)
            {
                var id = Session["UserID"];
                var user = db.USER.Find(id);
                var userid = user.ID;

                var id2 = Session["Status_ID"];
                var project = db.PROJECT_STATUS.Find(id2 = 3);
                var projectid = project.ID;
                var product = db.PROPERTY.Where(d => d.Status_ID == projectid && d.UserID == userid).ToList();
                return View(product);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }

        }

        [HttpGet]
        public ActionResult CreateNewProperty()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.District_ID = new SelectList(db.DISTRICT.Where(y => y.ID >= 31 && y.ID <= 54), "ID", "DistrictName");
                ViewBag.Status_ID = new SelectList(db.PROJECT_STATUS, "ID", "Status_Name");
                ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType");
                ViewBag.Street_ID = new SelectList(db.STREET.Where(y => y.ID >= 31 && y.ID <= 54), "ID", "StreetName");
                ViewBag.UserID = new SelectList(db.USER, "ID", "Email");
                ViewBag.Sale_ID = new SelectList(db.USER, "ID", "Email");
                ViewBag.Ward_ID = new SelectList(db.WARD.Where(y => y.ID >= 31 && y.ID <= 54), "ID", "WardName");
                ViewBag.Feature_ID = new SelectList(db.FEATURE, "ID", "FeatureName");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewProperty(PROPERTY property)
        {
            if (Session["UserID"] != null)
            {

                property.Avatar = AvatarUPost(property);
                property.Images = ImagesUPost(property);
                property.Created_at = DateTime.Now;
                property.Create_post = DateTime.Now;
                property.UnitPrice = "VND";
                property.Status_ID = 1;
                property.UserID = int.Parse(Session["UserID"].ToString());

                if (ModelState.IsValid)
                {

                    db.PROPERTY.Add(property);
                    db.SaveChanges();
                    var features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                    foreach (var feature in features)
                    {
                        var id = int.Parse(feature.Split('_')[1]);
                        if (Request.Form[feature].StartsWith("true"))
                        {
                            db.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                            {
                                Property_ID = property.ID,
                                Feature_ID = id
                            });
                        }
                    }
                    return RedirectToAction("ViewListMyProject", "AgencyProperty");
                }

                ViewBag.District_ID = new SelectList(db.DISTRICT, "ID", "DistrictName", property.District_ID);
                ViewBag.Status_ID = new SelectList(db.PROJECT_STATUS, "ID", "Status_Name", property.Status_ID);
                ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType", property.PropertyType_ID);
                ViewBag.Street_ID = new SelectList(db.STREET, "ID", "StreetName", property.Street_ID);
                ViewBag.UserID = new SelectList(db.USER, "ID", "Email", property.UserID);
                ViewBag.Sale_ID = new SelectList(db.USER, "ID", "Email", property.Sale_ID);
                ViewBag.Ward_ID = new SelectList(db.WARD, "ID", "WardName", property.Ward_ID);
                return View(property);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Draft(PROPERTY property)
        {
            if (Session["UserID"] != null)
            {

                property.Avatar = AvatarUPost(property);
                property.Images = ImagesUPost(property);
                property.Created_at = DateTime.Now;
                property.Create_post = DateTime.Now;
                property.UnitPrice = "VND";
                property.Status_ID = 2;
                property.UserID = int.Parse(Session["UserID"].ToString());

                if (ModelState.IsValid)
                {
                    db.PROPERTY.Add(property);
                    db.SaveChanges();
                    return RedirectToAction("ViewDraftProject", "AgencyProperty");
                }

                ViewBag.District_ID = new SelectList(db.DISTRICT, "ID", "DistrictName", property.District_ID);
                ViewBag.Status_ID = new SelectList(db.PROJECT_STATUS, "ID", "Status_Name", property.Status_ID);
                ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType", property.PropertyType_ID);
                ViewBag.Street_ID = new SelectList(db.STREET, "ID", "StreetName", property.Street_ID);
                ViewBag.UserID = new SelectList(db.USER, "ID", "Email", property.UserID);
                ViewBag.Sale_ID = new SelectList(db.USER, "ID", "Email", property.Sale_ID);
                ViewBag.Ward_ID = new SelectList(db.WARD, "ID", "WardName", property.Ward_ID);
                return View(property);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult DraftPOST(PROPERTY property)
        {
            if (Session["UserID"] != null)
            {

                property.Avatar = AvatarUPost(property);
                property.Images = ImagesUPost(property);
                property.Created_at = DateTime.Now;
                property.Create_post = DateTime.Now;
                property.UnitPrice = "VND";
                property.Status_ID = 1;
                property.UserID = int.Parse(Session["UserID"].ToString());

                if (ModelState.IsValid)
                {
                    db.PROPERTY.Add(property);
                    db.SaveChanges();
                    return RedirectToAction("ViewDraftProject", "AgencyProperty");
                }

                ViewBag.District_ID = new SelectList(db.DISTRICT, "ID", "DistrictName", property.District_ID);
                ViewBag.Status_ID = new SelectList(db.PROJECT_STATUS, "ID", "Status_Name", property.Status_ID);
                ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType", property.PropertyType_ID);
                ViewBag.Street_ID = new SelectList(db.STREET, "ID", "StreetName", property.Street_ID);
                ViewBag.UserID = new SelectList(db.USER, "ID", "Email", property.UserID);
                ViewBag.Sale_ID = new SelectList(db.USER, "ID", "Email", property.Sale_ID);
                ViewBag.Ward_ID = new SelectList(db.WARD, "ID", "WardName", property.Ward_ID);
                return View(property);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var project = db.PROPERTY.FirstOrDefault(x => x.ID == id);
            ViewBag.property_type = db.PROPERTY_TYPE.OrderByDescending(x => x.ID).ToList();
            ViewBag.district = db.DISTRICT.OrderByDescending(x => x.ID).Where(y => y.ID >= 31 && y.ID <= 54).ToList();
            ViewBag.ward = db.WARD.OrderByDescending(x => x.ID).Where(y => y.District_ID >= 31 && y.District_ID <= 54).ToList();
            ViewBag.street = db.STREET.OrderByDescending(x => x.ID).Where(y => y.District_ID >= 31 && y.District_ID <= 54).ToList();
            ViewBag.status = db.PROJECT_STATUS.OrderByDescending(x => x.ID).ToList();
            ViewBag.sale = db.USER.OrderByDescending(x => x.ID).ToList();
            return View(project);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(PROPERTY p)
        {
            PROPERTY en;
            string s;
            string b;
            AvatarU(p, out en, out s);
            ImagesU(p, out en, out b);

            en.PROPERTY_TYPE = p.PROPERTY_TYPE;
            en.PropertyName = p.PropertyName;
            en.Avatar = s;
            en.Images = b;
            en.PropertyType_ID = p.PropertyType_ID;
            en.Content = p.Content;
            en.Street_ID = p.Street_ID;
            en.Ward_ID = p.Ward_ID;
            en.District_ID = p.District_ID;
            en.Price = p.Price;
            en.UnitPrice = "VND";
            en.Area = p.Area;
            en.BedRoom = p.BedRoom;
            en.BathRoom = p.BathRoom;
            en.PackingPlace = p.PackingPlace;
            en.Status_ID = 2;
            en.Updated_at = DateTime.Now;
            en.Note = p.Note;
            db.SaveChanges();
            return RedirectToAction("ViewListMyProject", "AgencyProperty");
        }

        #region upload anh


        private string ImagesU(PROPERTY p)
        {

            string filename;
            string extension;
            string b;
            string s = "";
            try
            {
                foreach (var file in p.UpImages)
                {

                    if (file.ContentLength > 0)
                    {
                        filename = Path.GetFileNameWithoutExtension(file.FileName);
                        extension = Path.GetExtension(file.FileName);
                        filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                        p.Images = filename;
                        b = p.Images;
                        s = string.Concat(s, b, ",");
                        filename = Path.Combine(Server.MapPath("~/Images"), filename);
                        file.SaveAs(filename);

                    }

                }
                return s;
            }
            catch (NullReferenceException)
            {
                return s;
            }


        }
        private string AvatarU(PROPERTY p)
        {
            string s = "";
            string filename;
            string extension;


            if (p.AvatarUpload != null)
            {
                filename = Path.GetFileNameWithoutExtension(p.AvatarUpload.FileName);
                extension = Path.GetExtension(p.AvatarUpload.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                p.Avatar = filename;
                s = p.Avatar;
                filename = Path.Combine(Server.MapPath("~/Images"), filename);
                p.AvatarUpload.SaveAs(filename);
                return s;

            }
            return s;

        }


        private void AvatarU(PROPERTY p, out PROPERTY en, out string s)
        {
            en = db.PROPERTY.Find(p.ID);
            string filename;
            string extension;

            //try
            //{
            if (p.AvatarUpload != null)
            {
                filename = Path.GetFileNameWithoutExtension(p.AvatarUpload.FileName);
                extension = Path.GetExtension(p.AvatarUpload.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                p.Avatar = filename;
                s = p.Avatar;
                filename = Path.Combine(Server.MapPath("~/Images"), filename);
                p.AvatarUpload.SaveAs(filename);

            }
            else
            {
                s = en.Avatar;
            }
            //}
            //catch (NullReferenceException)
            //{
            //    return
            //}
        }
        private void ImagesU(PROPERTY p, out PROPERTY en, out string s)
        {
            en = db.PROPERTY.Find(p.ID);
            string filename;
            string extension;
            string b;
            s = "";

            if (p.UpImages == null)
            {
                s = en.Images;
            }

            else
            {

                foreach (var file in p.UpImages)
                {
                    try
                    {
                        if (file.ContentLength >= 0)
                        {
                            filename = Path.GetFileNameWithoutExtension(file.FileName);
                            extension = Path.GetExtension(file.FileName);
                            filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                            p.Images = filename;
                            b = p.Images;
                            s = string.Concat(s, b, ",");
                            filename = Path.Combine(Server.MapPath("~/Images"), filename);
                            file.SaveAs(filename);
                        }
                        else
                        {
                            s = en.Images;
                        }
                    }
                    catch (ArgumentNullException)
                    {

                    }
                }
            }
        }

        private string ImagesUPost(PROPERTY p)
        {
            string filename;
            string extension;
            string b;
            string s = "";
            foreach (var file in p.UpImages)
            {
                if (file != null)
                {
                    if (file.ContentLength >= 0)
                    {
                        filename = Path.GetFileNameWithoutExtension(file.FileName);
                        extension = Path.GetExtension(file.FileName);
                        filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                        p.Images = filename;
                        b = p.Images;
                        s = string.Concat(s, b, ",");
                        filename = Path.Combine(Server.MapPath("~/Images"), filename);
                        file.SaveAs(filename);
                    }
                }
            }
            return s;
        }
        private string AvatarUPost(PROPERTY p)
        {
            string s = "";
            string filename;
            string extension;

            if (p.AvatarUpload != null)
            {
                filename = Path.GetFileNameWithoutExtension(p.AvatarUpload.FileName);
                extension = Path.GetExtension(p.AvatarUpload.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                p.Avatar = filename;
                s = p.Avatar;
                filename = Path.Combine(Server.MapPath("~/Images"), filename);
                p.AvatarUpload.SaveAs(filename);
                return s;
            }
            return s;

        }
        #endregion
        public ActionResult Delete(int? id)
        {

            PROPERTY property = db.PROPERTY.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: /Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROPERTY property = db.PROPERTY.Find(id);
            db.PROPERTY.Remove(property);
            db.SaveChanges();
            return RedirectToAction("ViewDraftProject");
        }



    }
}