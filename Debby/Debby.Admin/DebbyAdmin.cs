using Debby.Admin.Core;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.FileSystems;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Internal;
using Microsoft.AspNet.Mvc.Routing;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Debby.Admin
{
    public static class MvcExtension
    {
        public static IApplicationBuilder UseDebby(
            this IApplicationBuilder app)
        {
            return app.UseDebby(DebbyAdmin.RegisterRoutes);
        }

        public static IApplicationBuilder UseDebby(
            this IApplicationBuilder app,
            Action<IRouteBuilder> configureRoutes)
        {
            MvcServicesHelper.ThrowIfMvcNotRegistered(app.ApplicationServices);

            var routes = new RouteBuilder
            {
                DefaultHandler = new MvcRouteHandler(),
                ServiceProvider = app.ApplicationServices
            };

            routes.Routes.Add(AttributeRouting.CreateAttributeMegaRoute(
                routes.DefaultHandler,
                app.ApplicationServices));

            configureRoutes(routes);

            return app.UseRouter(routes.Build());
        }

        private static IApplicationBuilder UseDebby(
            this IApplicationBuilder app,
            Action<IRouteBuilder, string> configureRoutes,
            string prefix = "DebbyAdmin")
        {
            MvcServicesHelper.ThrowIfMvcNotRegistered(app.ApplicationServices);

            var routes = new RouteBuilder
            {
                DefaultHandler = new MvcRouteHandler(),
                ServiceProvider = app.ApplicationServices
            };

            routes.Routes.Add(AttributeRouting.CreateAttributeMegaRoute(
                routes.DefaultHandler,
                app.ApplicationServices));

            configureRoutes(routes, prefix);


            return app.UseRouter(routes.Build());
        }
    }

    public class DebbyAdmin
    {
        public static IList<Entity> Entities { get; set; }

        static DebbyAdmin()
        {
            Entities = new List<Entity>();
        }

        public static Entity AddEntity<TEntity>()
        {
            var entity = new Entity(typeof(TEntity));
            Entities.Add(entity);

            return entity;
        }

        public static void RegisterRoutes(IRouteBuilder routes, string prefix = "DebbyAdmin")
        {
            routes.MapRoute(
                name: "DebbyAdminLogout",
                template: prefix + "/Logout",
                defaults: new { controller = "DebbyAdmin", action = "Logout" }
            );

            routes.MapRoute(
                name: "DebbyAdminCreate",
                template: prefix + "/{entityName}/Create",
                defaults: new { controller = "DebbyAdmin", action = "Create" }
            );

            routes.MapRoute(
                name: "DebbyAdminEdit",
                template: prefix + "/{entityName}/Edit/{key}",
                defaults: new { controller = "DebbyAdmin", action = "Edit" }
            );

            routes.MapRoute(
                name: "DebbyAdminDelete",
                template: prefix + "/{entityName}/Delete/{key}",
                defaults: new { controller = "DebbyAdmin", action = "Delete" }
            );

            routes.MapRoute(
                name: "DebbyAdminGroup",
                template: prefix + "/{groupName}/Group",
                defaults: new { controller = "DebbyAdmin", action = "Group" }
            );

            routes.MapRoute(
                name: "DebbyAdminChanges",
                template: prefix + "/{entityName}/Changes/{page}",
                defaults: new { controller = "DebbyAdmin", action = "Changes", page = 1 }
            );

            routes.MapRoute(
                name: "DebbyAdminList",
                template: prefix + "/{entityName}/{page}",
                defaults: new { controller = "DebbyAdmin", action = "List", page = 1 }
            );

            routes.MapRoute(
                name: "DebbyAdmin",
                template: prefix + "/{action}/{id?}",
                defaults: new { controller = "DebbyAdmin", action = "Index" }
            );
        }
    }
}