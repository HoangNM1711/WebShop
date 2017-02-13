﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{metatitle}-{categoryId}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "WebShop.Controllers" }
            );
            routes.MapRoute(
               name: "Product Detail",
               url: "chi-tiet/{metatitle}-{productId}",
               defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
               namespaces: new[] { "WebShop.Controllers" }
           );

            routes.MapRoute(
              name: "About",
              url: "gioi-thieu",
              defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "WebShop.Controllers" }
          );

            routes.MapRoute(
            name: "Cart",
            url: "gio-hang",
            defaults: new { controller = "CartItem", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "WebShop.Controllers" }
        );


            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "CartItem", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "WebShop.Controllers" }
           );

            routes.MapRoute(
               name: "Payment",
               url: "thanh-toan",
               defaults: new { controller = "CartItem", action = "Payment", id = UrlParameter.Optional },
               namespaces: new[] { "WebShop.Controllers" }
          );

            routes.MapRoute(
              name: "Payment Success",
              url: "hoan-thanh",
              defaults: new { controller = "CartItem", action = "Success", id = UrlParameter.Optional },
              namespaces: new[] { "WebShop.Controllers" }
         );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebShop.Controllers" }
            );
        }
    }
}
