using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPC.Models;
using System.IO;

namespace PPC.Areas.Admin.Controllers
{
    public class ProjectAdminController : Controller
    {
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();
        // GET: Admin/ProjectAdmin
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

        public ActionResult ViewListofAgencyProject()
        {
            if (Session["UserID"] != null)
            {
                if(Session["UserRole"].ToString() == "1" || Session["UserRole"].ToString() == "0")
                {
                    var r = db.USER.Where(x => x.Role != 0 && x.Role != 1);
                    var p = db.PROPERTY.Where(x => x.Status_ID != 3 && (x.USER.Role != 0 && x.USER.Role != 1)).ToList();
                    return View(p);
                }
                return RedirectToAction("Login", "Account", new { area = "" });

            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }

        }

        public ActionResult ViewListPersonalProject()
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

        //get viewlistprojectupapproved
        public ActionResult ViewListProjectUnapproved()
        {
            if (Session["UserID"] != null)
            {
                var id = Session["Status_ID"];
                var project = db.PROJECT_STATUS.Find(id=1);
                var project2 = db.PROJECT_STATUS.Find(id = 4);
                var projectid = project.ID;
                var projectid2 = project2.ID;
                var product = db.PROPERTY.Where(d => d.Status_ID == projectid || d.Status_ID == projectid2).ToList();
                return View(product);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }

        }

        [HttpGet]
        public ActionResult EditStatus(int? id)
        {
            ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType");
            ViewBag.Ward_ID = new SelectList(db.WARD.Where(y => y.ID >= 31 && y.ID <= 54), "ID", "WardName");
            ViewBag.District_ID = new SelectList(db.DISTRICT.Where(y => y.ID >= 31 && y.ID <= 54), "ID", "DistrictName");
            ViewBag.Street_ID = new SelectList(db.STREET.Where(y => y.ID >= 31 && y.ID <= 54), "ID", "StreetName");
            ViewBag.Status_ID = db.PROJECT_STATUS.OrderByDescending(x => x.ID).ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            PROPERTY pro = db.PROPERTY.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }

            return View(pro);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditStatus(PROPERTY p)
        {

            PROPERTY project = new PROPERTY();
            string s;
            string b;
            AvatarU(p, out project, out s);
            ImagesU(p, out project, out b);

            if (ModelState.IsValid)
            {

                project.Status_ID = p.Status_ID;
                project.Note = p.Note;

                project.PropertyName = p.PropertyName;
                project.Avatar = s;
                project.Images = b;
                project.PropertyType_ID = p.PropertyType_ID;
                project.Content = p.Content;
                project.Street_ID = p.Street_ID;
                project.Ward_ID = p.Ward_ID;
                project.District_ID = p.District_ID;
                project.Price = p.Price;
                project.UnitPrice = "VND";
                project.Area = p.Area;
                project.BedRoom = p.BedRoom;
                project.BathRoom = p.BathRoom;
                project.PackingPlace = p.PackingPlace;
                db.Entry(project).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewListofAgencyProject", "ProjectAdmin");
            }
            ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType");
            ViewBag.Ward_ID = new SelectList(db.WARD.Where(y => y.ID >= 31 && y.ID <= 54), "ID", "WardName");
            ViewBag.District_ID = new SelectList(db.DISTRICT.Where(y => y.ID >= 31 && y.ID <= 54), "ID", "DistrictName");
            ViewBag.Street_ID = new SelectList(db.STREET.Where(y => y.ID >= 31 && y.ID <= 54), "ID", "StreetName");
            ViewBag.Status_ID = db.PROJECT_STATUS.OrderByDescending(x => x.ID).ToList();
            return View(p);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var project = db.PROPERTY.FirstOrDefault(x => x.ID == id);
            ViewBag.property_type = db.PROPERTY_TYPE.OrderByDescending(x => x.ID).ToList();
            ViewBag.district = db.DISTRICT.OrderByDescending(x => x.ID).Where(y => y.ID >= 31 && y.ID <= 54).ToList();
            ViewBag.ward = db.WARD.OrderByDescending(x => x.ID).Where(y => y.District_ID >= 31 && y.District_ID <= 54).ToList();
            ViewBag.street = db.STREET.OrderByDescending(x => x.ID).Where(y => y.District_ID >= 31 && y.District_ID <= 54).ToList();
            ViewBag.Status_ID = db.PROJECT_STATUS.OrderByDescending(x => x.ID).ToList();
            ViewBag.sale = db.USER.OrderByDescending(x => x.ID).ToList();
            return View(project);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, PROPERTY p)
        {
            //PROPERTY product;
            PROPERTY en;
            string s;
            string b;
            AvatarU(p, out en, out s);
            ImagesU(p, out en, out b);
            if (ModelState.IsValid)
            {

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
                en.UnitPrice = p.UnitPrice;
                en.Area = p.Area;
                en.BedRoom = p.BedRoom;
                en.BathRoom = p.BathRoom;
                en.PackingPlace = p.PackingPlace;
                en.Updated_at = DateTime.Now;

                en.Status_ID = p.Status_ID;


                db.Entry(en).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewListofAgencyProject", "ProjectAdmin");
            }
            ViewBag.property_type = db.PROPERTY_TYPE.OrderByDescending(x => x.ID).ToList();
            ViewBag.district = db.DISTRICT.OrderByDescending(x => x.ID).Where(y => y.ID >= 31 && y.ID <= 54).ToList();
            ViewBag.ward = db.WARD.OrderByDescending(x => x.ID).Where(y => y.District_ID >= 31 && y.District_ID <= 54).ToList();
            ViewBag.street = db.STREET.OrderByDescending(x => x.ID).Where(y => y.District_ID >= 31 && y.District_ID <= 54).ToList();
            ViewBag.Status_ID = db.PROJECT_STATUS.OrderByDescending(x => x.ID).ToList();
            ViewBag.sale = db.USER.OrderByDescending(x => x.ID).ToList();
            return View(p);
        }
        [HttpGet]
        public ActionResult EditMe(int id)
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
        public ActionResult EditMe(int id, PROPERTY p)
        {
            //PROPERTY product;
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
            en.UnitPrice = p.UnitPrice;
            en.Area = p.Area;
            en.BedRoom = p.BedRoom;
            en.BathRoom = p.BathRoom;
            en.PackingPlace = p.PackingPlace;
            en.Updated_at = DateTime.Now;
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        private void AvatarU(PROPERTY p, out PROPERTY product, out string s)
        {
            product = db.PROPERTY.Find(p.ID);
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

            }
            else
            {
                s = product.Avatar;
            }
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

        public ActionResult Create()
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

        // POST: /Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PROPERTY property)
        {
            if (Session["UserID"] != null)
            {

                property.Avatar = AvatarUPost(property);
                property.Images = ImagesUPost(property);
                property.Created_at = DateTime.Now;
                property.Create_post = DateTime.Now;
                property.UnitPrice = "VND";
                // 1 chưa duyệt, 2 lưu nháp, 3 đã duyệt, 4 hết hạn
                property.Status_ID = 3;
                property.UserID = int.Parse(Session["UserID"].ToString());

                if (ModelState.IsValid)
                {

                    db.PROPERTY.Add(property);
                    db.SaveChanges();
                    return RedirectToAction("ViewListofAgencyProject", "ProjectAdmin");
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
                property.Status_ID = 2;   // 1 chưa duyệt, 2 lưu nháp, 3 đã duyệt, 4 hết hạn
                property.UserID = int.Parse(Session["UserID"].ToString());

                if (ModelState.IsValid)
                {
                    db.PROPERTY.Add(property);
                    db.SaveChanges();
                    return RedirectToAction("ViewListofAgencyProject", "ProjectAdmin");
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


        //public JsonResult GetStreet(int did)
        //{
        //    var db = new DemoPPCRentalEntities();
        //    var ward = db.STREET.Where(s => s.District_ID == did);
        //    return Json(ward.Select(s => new
        //    {
        //        id = s.ID,
        //        text = s.StreetName
        //    }), JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetWard(int did)
        //{
        //    var db = new DemoPPCRentalEntities();
        //    var ward = db.WARD.Where(s => s.District_ID == did);
        //    return Json(ward.Select(s => new
        //    {
        //        id = s.ID,
        //        text = s.WardName
        //    }), JsonRequestBehavior.AllowGet);


        //}

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
            return RedirectToAction("ViewListofAgencyProject");
        }
    }

    }
