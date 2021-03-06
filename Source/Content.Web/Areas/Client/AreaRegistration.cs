﻿using System.Web.Mvc;

namespace ContentNamespace.Web.Areas.Client
{
    public class ClientAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Client";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Client_default",
                "Client.mvc/{controller}/{action}/{id}",
                new { action = "Index", id = "" }
            );
        }
    }
}
