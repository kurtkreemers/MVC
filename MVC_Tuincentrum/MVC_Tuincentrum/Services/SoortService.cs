﻿using MVC_Tuincentrum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Tuincentrum.Services
{
    public class SoortService
    {
        public List<Soort> FindByBeginNaam(string beginNaam)
        {
            using (var db = new TuincentrumEntities())
            {
                var query = from soort in db.Soorten
                            where soort.Naam.StartsWith(beginNaam)
                            orderby soort.Naam
                            select soort;
                var soorten = query.ToList();
                return soorten;
            }
        }
    }
}