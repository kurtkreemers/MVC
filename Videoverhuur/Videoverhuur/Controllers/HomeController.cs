using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videoverhuur.Services;

namespace Videoverhuur.Controllers
{
    public class HomeController : Controller
    {
        private VerhuurService db = new VerhuurService();
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
        public ActionResult Aanmelden()
        { 
            if (Request["zoek"] != null)
            {
                var naam = Request["naam"];
                var postcode = Request["postcode"];
                var klant = db.GetKlant(naam,postcode);
                if (klant != null)
                {
                    Session["klant"] = klant;
                    ViewBag.message = "Ga naar verhuringen";
                }
                else
                    ViewBag.Message = "Foutieve gegevens, probeer opnieuw";
            }
            return View();
        }
    }
}