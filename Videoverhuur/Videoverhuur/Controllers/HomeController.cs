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
            Session["Klant"] = null;
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
                var klant = db.GetKlant(naam, postcode);
                if (klant != null)
                {
                    Session["Klant"] = klant;
                }
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

        public ActionResult Verhuren(int id)
        {
            Session[id.ToString()] = id;
            return RedirectToAction("Mandje", "Home");

        }
        public ActionResult Mandje()
        {
            List<MandjeItem> mandjeItems = new List<MandjeItem>();
            foreach (string nummer in Session)
            {
                int filmnummer;
                if (int.TryParse(nummer, out filmnummer))
                {
                    Film film = db.GetFilm(filmnummer);
                    MandjeItem mandjeItem = new MandjeItem(film.BandNr, film.Titel, film.Prijs);
                    mandjeItems.Add(mandjeItem);
                }
            }
            return View(mandjeItems);
        }
        public ActionResult Verwijderen(int id)
        {
            Film film = db.GetFilm(id);
            return View(film);
        }
        public ActionResult Verwijdering(int id)
        {
            if (Session[id.ToString()] != null)
                Session.Remove(id.ToString());
            return RedirectToAction("Mandje", "Home");
        }
        public ActionResult Afrekenen()
        {
            List<MandjeItem> mandjeItems = new List<MandjeItem>();
            List<Film> films = new List<Film>();
            List<Verhuur> verhuringen = new List<Verhuur>();
            decimal Totaal = 0;
            var klant = (Klant)Session["klant"];
            foreach (string nummer in Session)
            {
                int filmnummer;
                if (int.TryParse(nummer, out filmnummer))
                {
                    Film film = db.GetFilm(filmnummer);
                    MandjeItem mandjeItem = new MandjeItem(film.BandNr, film.Titel, film.Prijs);
                    mandjeItems.Add(mandjeItem);
                    Totaal += mandjeItem.Prijs;

                    film.InVoorraad -= 1;
                    film.UitVoorraad += 1;
                    films.Add(film);

                    Verhuur verhuring = new Verhuur();
                    verhuring.BandNr = film.BandNr;
                    if (klant != null)
                    {
                        verhuring.KlantNr = klant.KlantNr;

                    }
                    verhuring.VerhuurDatum = DateTime.Today;
                    verhuringen.Add(verhuring);
                }

            }
            db.Bewaar(films, verhuringen);
            ViewBag.Totaal = String.Format("{0:0.00}", Totaal);
            if (klant != null)
            {
                ViewBag.KlantNaam = klant.Voornaam + " " + klant.Naam;
                ViewBag.KlantStraat = klant.Straat_Nr;
                ViewBag.KlantGemeente = klant.PostCode + " " + klant.Gemeente;
            }
            Session.RemoveAll();
            return View(mandjeItems);
        }
    }
}