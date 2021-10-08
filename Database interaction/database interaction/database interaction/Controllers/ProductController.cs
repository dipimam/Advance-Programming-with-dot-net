using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
        public ActionResult Cart()
        {
         //   Session['id']=id;

            return View("");
        }
      
        [HttpGet]
        public ActionResult Update(int id)
        {
            Database db = new Database();
            var p = db.products.Get(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            Database db = new Database();
           db.products.Update(product);
            return RedirectToAction("Read");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Database db = new Database();
            db.products.Delete(id);
            return RedirectToAction("Read");
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Shop()
        {
            Database db = new Database();
            var products = db.products.GetAll();
            return View(products);
        }

        public ActionResult AddtoCart(int id)
        {
            Database db = new Database();
            var p = db.products.Get(id);

            if(Session["cart"]==null)
            {
                List<Product> cartproduct = new List<Product>();
                cartproduct.Add(p);
                var json = new JavaScriptSerializer().Serialize(cartproduct);
                Session["cart"] = json;
                return RedirectToAction("Shop");
            }
            else
            {
                var cart = Session["cart"];
                var cartproduct= new JavaScriptSerializer().Deserialize<List<Product>>(cart.ToString());
                cartproduct.Add(p);
                var json = new JavaScriptSerializer().Serialize(cartproduct);
                Session["cart"] = json;
                return RedirectToAction("Shop");

            }
        }
        public ActionResult ShowCart()
        {
            if (Session["cart"] != null)
            {
                var cart = Session["cart"];
                var cartproduct = new JavaScriptSerializer().Deserialize<List<Product>>(cart.ToString());
                return View(cartproduct);
            }
            else
            {
                return View();
            }
        }
        public ActionResult DeleteOrder(int id)
        {
            Database db = new Database();
            var p = db.products.Get(id);
            var cart = Session["cart"];
            var cartproduct = new JavaScriptSerializer().Deserialize<List<Product>>(cart.ToString());
            var item = cartproduct.SingleOrDefault(x => x.id == id);
            if (item != null)
                cartproduct.Remove(item);

            var json = new JavaScriptSerializer().Serialize(cartproduct);
            Session["cart"] = json;

            return RedirectToAction("ShowCart");

        }

        public ActionResult ConfirmOrder()
        {
            if(Session["cart"]!=null)
            {
                Database db = new Database();
               
                var cart = Session["cart"];
                var cartproduct = new JavaScriptSerializer().Deserialize<List<Product>>(cart.ToString());

                order o = null;
                foreach(var p in cartproduct)
                {
                   o= new order();
                    

                    o.name = p.name;
                    o.price = p.price;
                    o.p_id = p.id;
                    o.time = DateTime.Now.ToString("dd/MM/yyyy");
                    db.order.Add(o);


                }
            }
            return RedirectToAction("Shop");
        }
        

        
        

        
    }

    
}