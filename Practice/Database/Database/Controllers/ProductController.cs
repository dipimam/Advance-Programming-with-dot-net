using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Database.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            database_interaction_dbEntities db = new database_interaction_dbEntities();
            var data = db.products.ToList();

            return View(data);
        }
    }
}