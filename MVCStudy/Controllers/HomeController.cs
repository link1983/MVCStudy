using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStudy.Models;

namespace MVCStudy.Controllers
{
    public class HomeController : Controller
    {
        Product myProduct = new Product
        {
            ProductID = 1,
            Name = "Bot",
            Description = "A Robot",
            Category = "Machine",
            Price = 19.99M
        };

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Ge = "dsdfs";
            return View(myProduct);
        }
    }
}