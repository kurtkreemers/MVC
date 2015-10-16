﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBierenApplication.Models;

namespace MVCBierenApplication.Controllers
{
    public class BierController : Controller
    {
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
    }
}