using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpload.Models;

namespace DemoUpload.Controllers
{
    public class BrandController : Controller
    {
       
            private ApplicationDbContext _context;

            public BrandController()
            {
                _context = new ApplicationDbContext();
            }

            protected override void Dispose(bool disposing)
            {
                _context.Dispose();
            }

            // GET: Product
            public ViewResult Index()
            {
              //  var products = _context.Brand.ToList();



                return View();

            }



            public ActionResult SaveImage()
        {
            var product = new Brand();

            return View(product);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ViewImage(int id)
        {
            var item = _context.Brands.Find(id);
            byte[] buffer = item.BrandImage;
            return File(buffer, "image/jpg", string.Format("{0}.jpg", id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveImage(HttpPostedFileBase uploadImages)
        {
          
                if (uploadImages.ContentLength > 0)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImages.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImages.ContentLength);
                    }
                    var product = new Brand()
                    {
                        BrandImage = imageData

                    };
                    _context.Brands.Add(product);
                }
            
            _context.SaveChanges();
            return Content("Success!");
        }

    }
}