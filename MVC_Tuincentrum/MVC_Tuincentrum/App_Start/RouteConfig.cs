﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace MVC_Tuincentrum
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("values", typeof(ValuesConstraint));
            routes.MapMvcAttributeRoutes(constraintsResolver);

            routes.MapRoute(
                "FindPlantenByPrijsBetween",
                "planten",
                new { controller = "Plant", action = "FindPlantenBetweenPrijzen" },
                new {QueryConstraint = new QueryStringConstraint(new string[] { "minprijs", "maxprijs" }) });

            routes.MapRoute(
                "FindPlantenByKleur",
                "planten",
                new { controller = "Plant", action = "FindPlantenVanEenKleur" },
                new { QueryConstraint = new QueryStringConstraint(new string[] { "kleur" }) });

            routes.MapRoute(
                "PlantenVanEenLeverancier",
                "leverancier/{levnr}/planten",
                new { controller = "Plant", action = "FindPlantenByLeverancier" });

            routes.MapRoute(
                "PlantenVanEenSoort",
                "soort/{soortnaam}/planten",
                new { controller = "Plant", action = "FindPlantenBySoortNaam" } );

            routes.MapRoute(
                "Alleplanten",
                "Plantenlijst",
                new { controller = "Plant", action = "Index" });

            routes.MapRoute(
                "PlantByNr",
                "Plant/{id}",
                new { controller = "Plant", action = "Details" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

        }
    }
}
