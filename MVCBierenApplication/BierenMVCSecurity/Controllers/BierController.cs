using BierenMVCSecurity.Models;
using BierenMVCSecurity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BierenMVCSecurity.Controllers
{
    public class BierController : Controller
    {
        private BierService Bieren = new BierService();

        // GET: Bier
        public ActionResult Index()
        {
            var bierenLijst = Bieren.FindAll();
            return View(bierenLijst);


        }
         [Authorize(Roles = "Administrator")]
        public ActionResult Verwijderen(int id)
        {
            var bier = Bieren.Read(id);
            return View(bier);
        }
        [HttpPost]
        public ActionResult DeleteView(int id)
        {
            var bier = Bieren.Read(id);
            this.TempData["bier"] = bier;
            Bieren.Delete(id);
            return RedirectToAction("Verwijderd");
        }


        public ActionResult verwijderd()
        {
            var bier = (Bier)TempData["Bier"];
            return View(bier);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Toevoegen()
        {
            var bier = new Bier();
            return View(bier);
        }

        [HttpPost]
       
        public ActionResult Toevoegen(Bier b)
        {
            if (this.ModelState.IsValid)
            {
                Bieren.Add(b);
                return RedirectToAction("Index");
            }
            else
                return View(b);
        }
    }
}