﻿using System.Web.Mvc;

namespace EventsTacLocal.Areas.Importer
{
    public class ImporterAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Importer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Importer_default",
                "Importer/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}