using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ecommerce.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ViewProduct()
        {
            using (ecommerce_dbEntities db = new ecommerce_dbEntities())
            {
                var entity = db.Products.ToList();

                return View(entity);
            }
            
        }
        public ActionResult AddtoCart(int id)
        {
            ecommerce_dbEntities db = new ecommerce_dbEntities();
           // db.Configuration.ProxyCreationEnabled = false;
            var entity = (from p in db.Products
                          where p.p_id == id
                          select p).FirstOrDefault();
          

            if (Session["cart"] == null)
            {
                
                List<Product> cartproduct = new List<Product>();
                cartproduct.Add(entity);
                var json = new JavaScriptSerializer().Serialize(cartproduct);
                Session["cart"] = json;
                return RedirectToAction("ViewProduct");
            }
            else
            {
                var cart = Session["cart"];
                var cartproduct = new JavaScriptSerializer().Deserialize<List<Product>>(cart.ToString());
                cartproduct.Add(entity);
                var json = new JavaScriptSerializer().Serialize(cartproduct);
                Session["cart"] = json;
                return RedirectToAction("ViewProduct");

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
            ecommerce_dbEntities db = new ecommerce_dbEntities();

            var p = (from pro in db.Products
                     where pro.p_id == id
                     select pro).FirstOrDefault();

            var cart = Session["cart"];
            var cartproduct = new JavaScriptSerializer().Deserialize<List<Product>>(cart.ToString());
            var item = cartproduct.FirstOrDefault(x => x.p_id == id);
            if (item != null)
                cartproduct.Remove(item);

            var json = new JavaScriptSerializer().Serialize(cartproduct);
            Session["cart"] = json;

            return RedirectToAction("ShowCart");

        }

        public ActionResult ConfirmOrder()
        {
            if (Session["cart"] != null)
            {
                ecommerce_dbEntities db = new ecommerce_dbEntities();
                


                

                var cart = Session["cart"];
                var cartproduct = new JavaScriptSerializer().Deserialize<List<Product>>(cart.ToString());

                Order o = null;
                foreach (var p in cartproduct)
                {
                    o = new Order();


                    o.p_id = p.p_id;
                    o.status = "Ordered";
                    o.c_id = Convert.ToInt32(User.Identity.Name);
                    o.time = DateTime.Now.ToString("dd/MM/yyyy");
                    db.Orders.Add(o);
                    db.SaveChanges();


                }
                Session.Contents.RemoveAll();
            }
            return RedirectToAction("ViewProduct");
        }
    }
}