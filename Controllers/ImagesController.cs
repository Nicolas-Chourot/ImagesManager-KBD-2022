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

        // GET: Images
        public ActionResult Index()
        {
            return View(DB.Images.OrderByDescending(i => i.CreationDate));
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
            return RedirectToAction("Index");
        }
    }
}