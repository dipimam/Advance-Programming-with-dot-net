using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Tree_Plantation.BModel;
using Tree_Plantation.Models;
using Tree_Plantation.Models.Repository;

namespace Tree_Plantation.Controllers
{
    [Authorize]
    public class AssignmentController : Controller
    {
        // GET: Assignment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ArrangeCampaign()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ArrangeCampaign(ArrangeCampaign campaign)
        {
            if(ModelState.IsValid)
            {
            
                var json = new JavaScriptSerializer().Serialize(campaign);
                Session["assignment"] = json;
                return RedirectToAction("AssignedVolunteer");
            }
            return View();
        }

        public ActionResult AssignedVolunteer()
        {
            var entity = AssignmentRepository.GetAll();

            return View(entity);
        }

        public ActionResult AddtoCampaign(int id)
        {
            var v = AssignmentRepository.Get(id);
            bool flag = false;

               if (Session["volunteer"] == null)
               {

                   List<volunteer> cartvolunteer= new List<volunteer>();
                    cartvolunteer.Add(v);
                   var json = new JavaScriptSerializer().Serialize(cartvolunteer);
                   Session["volunteer"] = json;
                   return RedirectToAction("AssignedVolunteer");
               }
               else
               {
                   var cart = Session["volunteer"];
                   var cartvolunteer = new JavaScriptSerializer().Deserialize<List<volunteer>>(cart.ToString());
                   foreach(var item in cartvolunteer)
                {
                    if(item.v_id==v.v_id)
                    {
                        flag = true;
                    }
                }
                   if(flag==false)
                {
                    cartvolunteer.Add(v);
                }
                    
                   var json = new JavaScriptSerializer().Serialize(cartvolunteer);
                   Session["volunteer"] = json;
                   return RedirectToAction("AssignedVolunteer");

               }
        }

        public ActionResult ShowCart()
        {
            if (Session["volunteer"] != null)
            {
                var cart = Session["volunteer"];
                var cartvolunteer = new JavaScriptSerializer().Deserialize<List<volunteer>>(cart.ToString());
                return View(cartvolunteer);
            }
            else
            {
                return View();
            }
        }

        public ActionResult ConfirmCampaign()
        {
            if (Session["volunteer"]!=null)
            {
                if(Session["assignment"]!=null)
                {
                    var time = DateTime.Now.ToString("h:mm:ss tt");

                    var cart = Session["volunteer"];
                    var cartvolunteer = new JavaScriptSerializer().Deserialize<List<volunteer>>(cart.ToString());

                    var assignment = Session["assignment"];
                    var cartassignment = new JavaScriptSerializer().Deserialize<ArrangeCampaign>(assignment.ToString());

                    AssignmentRepository.ArrangeCampaign(cartassignment, time);
                    AssignmentRepository.AssignedVolunteer(cartvolunteer, time);

                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}