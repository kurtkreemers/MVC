using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videoverhuur.Models;
using Videoverhuur.Services;

namespace Videoverhuur.Controllers
{
    public class HomeController : Controller
    {

        private VerhuurService db = new VerhuurService();
        public ActionResult Index()
        {
            ViewBag.Login = "Eerst aanmelden om te kunnen huren !";
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
                    ViewBag.login = "Welkom, " + klant.Voornaam + " " + klant.Naam;
                }
                else
                    ViewBag.login = "Eerst aanmelden om te kunnen verhuren ! ";
                return View(klant);
            }
            return View();
           
        }
        public ActionResult Genres()
        {       
            List<Genre> alleGenres = db.GetAllGenres();       
            return View(alleGenres);
        }

        public ActionResult Detail(int id)
        {
            List<Film> filmsVanGenre = db.GetAlleFilmsVanGenre(id);
            ViewBag.Genre = db.GetGenre(id).GenreSoort;
            return View(filmsVanGenre);
        }
    }
}