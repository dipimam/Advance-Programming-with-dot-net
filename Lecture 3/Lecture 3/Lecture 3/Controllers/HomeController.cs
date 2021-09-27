using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture_3.Controllers
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
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Resister()
        {
            string connString = @"Server=DESKTOP-NM0ID5F\SQLEXPRESS;Database=UMS_A;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            string query = String.Format("Insert into Students values ('{0}','{1}','{2}',0.0)", s.Name, s.Dob, s.Gender);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            return View();
        }
    }
}