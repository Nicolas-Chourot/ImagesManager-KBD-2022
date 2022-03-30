using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImagesManager.Models;

namespace ImagesManager.Controllers
{
    public class ImagesController : Controller
    {
        ImagesDBEntities DB = new ImagesDBEntities();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DB.Dispose();
            }
            base.Dispose(disposing);
        }

        public void RenewImagesSerialNumber()
        {
            HttpRuntime.Cache["imagesSerialNumber"] = Guid.NewGuid().ToString();
        }

        public string GetImagesSerialNumber()
        {
            if (HttpRuntime.Cache["imagesSerialNumber"] == null)
            {
                RenewImagesSerialNumber();
            }
            return (string)HttpRuntime.Cache["imagesSerialNumber"];
        }

        public void SetLocalImagesSerialNumber()
        {
            Session["imagesSerialNumber"] = GetImagesSerialNumber();
        }

        public bool IsImagesUpToDate()
        {
            return ((string)Session["imagesSerialNumber"] == (string)HttpRuntime.Cache["imagesSerialNumber"]);
        }

        // GET: Images
        public ActionResult Index()
        {
            SetLocalImagesSerialNumber();
            return View();
        }

        public PartialViewResult GetImages(bool forceRefresh = false)
        {
            if (forceRefresh || !IsImagesUpToDate())
            {
                SetLocalImagesSerialNumber();
                return PartialView(DB.Images.OrderByDescending(i => i.CreationDate));
            }
            return null;
        }
        public ActionResult Create()
        {
            return View(new Image());
        }
        [HttpPost]
        public ActionResult Create(Image image)
        {
            if (ModelState.IsValid)
            {
                DB.Add_Image(image);
                RenewImagesSerialNumber();
                return RedirectToAction("Index");
            }
            return View(image);
        }
        public ActionResult Edit(int id)
        {
            Image image = DB.Images.Find(id);
            if (image != null)
                return View(image);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Image image)
        {
            if (ModelState.IsValid)
            {
                DB.Update_Image(image);
                RenewImagesSerialNumber();
                return RedirectToAction("Index");
            }
            return View(image);
        }
        public ActionResult Details(int id)
        {
            Image image = DB.Images.Find(id);
            if (image != null)
                return View(image);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            DB.Remove_Image(id);
            RenewImagesSerialNumber();
            return RedirectToAction("Index");
        }
    }
}