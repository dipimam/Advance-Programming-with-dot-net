using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ecommerce.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            using(ecommerce_dbEntities db= new ecommerce_dbEntities())
            {
                var entity = (from c in db.Customers
                              where c.c_phone == customer.c_phone 
                              && c.c_password== customer.c_password
                              select c).FirstOrDefault();

                if(entity!=null)
                {
                    FormsAuthentication.SetAuthCookie(entity.c_id.ToString(),true);

                    return RedirectToAction("ViewProduct", "Product");
                }
                else
                {
                    ViewBag.Message = "Incorrect Phone or Password";

                    return View();
                }
            }

            
        }
        [HttpGet]
        public ActionResult CreateAccountCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccountCustomer(Customer customer)
        {
          if(ModelState.IsValid)
            {
                Customer entity = new Customer();
                entity.c_name = customer.c_name;
                entity.c_phone = customer.c_phone;
                entity.c_email = customer.c_email;
                entity.c_password = customer.c_password;
                entity.c_address = customer.c_address;

                using (ecommerce_dbEntities db = new ecommerce_dbEntities())

                {
                    db.Customers.Add(entity);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                
            }
            return View();
            
        }
    }
}