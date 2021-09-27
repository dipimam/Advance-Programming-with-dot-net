using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using database_interaction.Models;
using database_interaction.Models.Entity;

namespace database_interaction.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.products.Add(p);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Read()
        {
            Database db = new Database();
            var products = db.products.GetAll();
            return View(products);
        }
    }
}