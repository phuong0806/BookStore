using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );

            routes.MapRoute(
             name: "Danh mục",
             url: "the-loai",
             defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "SanGiaoDichBatDongSan.Controllers" }
         );
        }
    }
}
