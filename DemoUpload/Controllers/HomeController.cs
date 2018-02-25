using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpload.Models;

namespace DemoUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddImage()
        {
            Brand brandImage = new Brand();
            return View(brandImage);
        }

        [HttpPost]
        public ActionResult AddImage(Brand model, HttpPostedFileBase image1)
        {
            var db = new ApplicationDbContext();
            if(image1 != null)
            {
                model.BrandImage = new byte[image1.ContentLength];
                image1.InputStream.Read(model.BrandImage,0,image1.ContentLength);
            }

            db.Brands.Add(model);
            db.SaveChanges();
            return View(model);
        }
        public ActionResult ViewImage()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var item = (from d in db.Brands
                select d).ToList();
            return View(item);
        }
    }
}