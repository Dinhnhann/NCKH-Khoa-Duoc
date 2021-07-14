﻿using System.Web.Mvc;

namespace _2021NCKH.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Login", controller = "Admin", id = UrlParameter.Optional },
                namespaces: new[] { "_2021NCKH.Areas.Admin.Controllers" }
            );
        }
    }
}