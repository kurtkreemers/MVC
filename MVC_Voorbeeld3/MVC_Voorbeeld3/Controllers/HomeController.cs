using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string resultaat = "Dit is jouw eerste bezoek";
            //if (Request.Cookies != null)
            //{
            //    if (Request.Cookies["lastvisit"] != null)
            //    {
            //        resultaat = "Welkom terug. Jouw laatste bezoek was op " + Request.Cookies["lastvisit"]["tijdstip"] +
            //            ". Jouw voorkeurtaal is " + Request.Cookies["lastvisit"]["taal"] + ".";
            //    }
            //    string laatsteBezoek = DateTime.Now.ToString(); 
            //    var userCookie = new HttpCookie("lastvisit"); 
            //    userCookie["tijdstip"] = laatsteBezoek;
            //    userCookie["taal"] = Request.UserLanguages[0];
            //    userCookie.Expires = DateTime.Now.AddDays(365);
            //    Response.Cookies.Add(userCookie);
            //}
            //ViewBag.Tijdstip = resultaat;
            this.Session["aantalbezoeken"] = (int)this.Session["aantalbezoeken"] + 1;

            System.Web.HttpContext.Current.Application.Lock(); System.Web.HttpContext.Current.Application["aantalbezoeken"] = (int)System.Web.HttpContext.Current.Application["aantalbezoeken"] + 1;
            System.Web.HttpContext.Current.Application.UnLock();
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
        public ActionResult Wissen()
        {
            this.Session["aantalbezoeken"] = 0;

            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["aantalbezoeken"] = 0;
            System.Web.HttpContext.Current.Application.UnLock();

            return View();
        }
    }
}