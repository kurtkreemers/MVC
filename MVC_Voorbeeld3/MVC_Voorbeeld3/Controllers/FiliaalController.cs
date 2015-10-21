using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Voorbeeld3.Services;
using MVC_Voorbeeld3.Models;

namespace MVC_Voorbeeld3.Controllers
{
    
    public class FiliaalController : Controller
    {
        private FiliaalService filiaalservice = new FiliaalService();
        private HoofdZetelService hoofdZetelService = new HoofdZetelService();
        // GET: Filiaal
        public ActionResult Index()
        {
            var hoofdZetel = hoofdZetelService.Read();
            ViewBag.hoofdZetel = hoofdZetel;
            var filialen = filiaalservice.FindAll();
            return View(filialen);
        }
        public ActionResult Verwijderen(int id)
        {
            var filiaal = filiaalservice.Read(id);
            return View(filiaal);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var filiaal = filiaalservice.Read(id);
            this.TempData["filiaal"] = filiaal;
            filiaalservice.Delete(id);
            return RedirectToAction("Verwijderd", "Filiaal");
        }
        public ActionResult Verwijderd()
        {
            var filiaal = (Filiaal)this.TempData["filiaal"];
            return View(filiaal);
        }
    }

}