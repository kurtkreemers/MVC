using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld2.Controllers
{
    public class WerknemerController : Controller
    {
        // GET: Werknemer
        public ActionResult Index()
        {
            return View("AndereNaam");
        }
        [NonAction]
        public void GeenAction()
        {

        }
        [HttpPost]
        public ActionResult VerdubbelDeWeddes()
        {
            return View();
        }
    }
}