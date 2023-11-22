
using System.Net.Mime;
using System.Text.RegularExpressions;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{


    public class FirstController : Controller
    {
        private readonly IWebHostEnvironment _env;

        private readonly ProductService _productService;
        public FirstController(IWebHostEnvironment env, ProductService productService)
        {
            _env = env;
            _productService = productService;
        }
        public string Index()
        {
            return "Toi la Index cua First";
        }

        public IActionResult Readme()
        {
            var content = @"
            xin chao cac ban,
            Cac ban dang hoc MVC


            Quang Huy
            ";
            return Content(content, "text/plain");
        }

        public IActionResult Bird()
        {
            string filePath = Path.Combine(_env.ContentRootPath, "Files", "Bird.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            string contenTypes = MimeKit.MimeTypes.GetMimeType(filePath);

            var cd = new ContentDisposition
            {
                FileName = filePath,
                Inline = true,
            };

            Response.Headers.Add("Content-Disposition", cd.ToString());

            return File(bytes, contenTypes);
        }

        public IActionResult HelloView(string userName)
        {
            if (userName == null)
            {
                userName = "Khach";
            }
            // return View("/MyView/xinchao1.cshtml");
            // return View("/MyView/xinchao1.cshtml",userName);

            //View/First/xincaho2.cshtml
            // return View("xinchao2",userName);
            //View/First/HelloView.cshtml 
            return View((object)userName);

        }

        [TempData]
        public string StatusMessage { get; set; }
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                // TempData["StatusMessage"] = "San pham ban yeu cau khong co" ; 
                StatusMessage = "San pham ban yeu cau khong co ";
                return Redirect(Url.Action("Index", "Home"));
            }

            //Model
            // return View(product);

            //ViewData
            // this.ViewData["product"] = product;
            // return View("ViewProduct2");

            ViewBag.product = product;
            return View("ViewProduct3");
        }


    }
}
