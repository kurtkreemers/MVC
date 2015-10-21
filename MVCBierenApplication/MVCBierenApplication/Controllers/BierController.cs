using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBierenApplication.Models;
using MVCBierenApplication.Services;

namespace MVCBierenApplication.Controllers
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
    }
}