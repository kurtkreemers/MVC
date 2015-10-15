using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Voorbeeld3.Services;

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
    }
}