using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPProject.Controllers
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

        public ActionResult Plans()
        {
            ViewBag.Message = "Your plans page.";
            return View();
        }

        public ActionResult GuestPlan()
        {
            ViewBag.Message = "Your guest plans page.";
            return View();
        }

        public ActionResult EditService()
        {
            ViewBag.Message = "Your page to change service.";
            return View();
        }


    }
}