using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBierenApplication.Models;

namespace MVCBierenApplication.Controllers
{
    public class BierController : Controller
    {
        private static Dictionary<int, Bier> bierenDictionary = new Dictionary<int, Bier>();
        // GET: Bier
        public ActionResult Index()
        {
            var bieren = new List<Bier>();

            bieren.Add(new Bier { ID = 1, Naam = "Jupiler", Alcohol = 0.8f });
            bieren.Add(new Bier { ID = 2, Naam = "Leffe", Alcohol = 2.2f });
            bieren.Add(new Bier { ID = 3, Naam = "Hoegaarden", Alcohol = 5.3f });
            bieren.Add(new Bier { ID = 4, Naam = "Stella Artois", Alcohol = 8.3f });

            return View(bieren);
        }
        public ActionResult Verwijderen(int id)
        {
            var bier = Read(id);

            return View(bier);
        }
        public ActionResult DeleteView(int id)
        {
            var bier = Read(id);
            this.TempData["bier"] = bier;
            Delete(id);
            return Redirect("~/Bier/Verwijderd");
        }
        public Bier Read(int id)
        {
            return bierenDictionary[id];
        }

        public void Delete(int id)
        {
          bierenDictionary.Remove(id);
        }

    }
}