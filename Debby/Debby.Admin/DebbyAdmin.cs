using System;
using System.Collections.Generic;
using Debby.Admin.Core.GenericControllers;
using Debby.Admin.Core.ModelBinders;
using Debby.Admin.Core.ModelConnectors;
using Debby.Admin.Core.ModelConnectors.Interfaces;
using Debby.Admin.Services;
using Debby.Admin.Services.Interfaces;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Internal;
using Microsoft.AspNet.Mvc.Routing;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;

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

    public static class MvcServiceCollectionExtensions
    {
        public static IServiceCollection AddDebby
            <TModelConnector>(
            this IServiceCollection services,
            IConfiguration configuration = null)
            where TModelConnector : IModelConnector
        {
            //Add EF services to the services container.
            services.AddSingleton<IEntityService, EntityService>();
            services.AddSingleton<IModelConnector, TModelConnector>();

            services.Configure<MvcOptions>(options =>
            {
                options.ModelBinders.Add(typeof(DynamicModelBinder));
            });

            services.AddTransient<IActionDiscoveryConventions, GenericActionDiscoveryConventions>();
            services.AddTransient<INestedProvider<ActionInvokerProviderContext>, GenericControllerActionInvokerProvider>();
            services.AddTransient<IControllerFactory, DebbyControllerFactory>();

            return services;
        }

        public static IServiceCollection AddDebby(
        this IServiceCollection services,
        IConfiguration configuration = null)
        {
            return services.AddDebby<DefaultModelConnector>(configuration);
        }
    }

    public static class DebbyAdmin
    {
        private const string ControllerName = "GenericController`1";

        public static IList<Type> Entities { get; set; }

        static DebbyAdmin()
        {
            Entities = new List<Type>();
        }

        public static void AddEntity<TEntity>()
        {
            Entities.Add(typeof(TEntity));
        }

        public static void RegisterRoutes(IRouteBuilder routes, string prefix = "DebbyAdmin")
        {
            routes.MapRoute(
                name: "DebbyAdminLogout",
                template: prefix + "/Logout",
                defaults: new { controller = ControllerName, action = "Logout" }
            );

            routes.MapRoute(
                name: "DebbyAdminCreate",
                template: prefix + "/{entityName}/Create",
                defaults: new { controller = ControllerName, action = "Create" }
            );

            routes.MapRoute(
                name: "DebbyAdminEdit",
                template: prefix + "/{entityName}/Edit/{key}",
                defaults: new { controller = ControllerName, action = "Edit" }
            );

            routes.MapRoute(
                name: "DebbyAdminDelete",
                template: prefix + "/{entityName}/Delete/{key}",
                defaults: new { controller = ControllerName, action = "Delete" }
            );

            routes.MapRoute(
                name: "DebbyAdminGroup",
                template: prefix + "/{groupName}/Group",
                defaults: new { controller = ControllerName, action = "Group" }
            );

            routes.MapRoute(
                name: "DebbyAdminList",
                template: prefix + "/{entityName}/{page}",
                defaults: new { controller = ControllerName, action = "List", page = 1 }
            );

            routes.MapRoute(
                name: "DebbyAdminChanges",
                template: prefix + "/{entityName}/Changes/{page}",
                defaults: new { controller = ControllerName, action = "Changes", page = 1 }
            );

            routes.MapRoute(
                name: "DebbyAdmin",
                template: prefix + "/{action}/{id?}",
                defaults: new { controller = "DebbyAdmin", action = "Index" }
            );
        }
    }
}