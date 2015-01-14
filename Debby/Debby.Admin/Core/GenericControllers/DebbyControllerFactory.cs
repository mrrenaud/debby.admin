using System;
using System.Linq;
using Debby.Admin.Controllers;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;

namespace Debby.Admin.Core.GenericControllers
{
    public class DebbyControllerFactory : IControllerFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ITypeActivator _typeActivator;
        private readonly IControllerActivator _controllerActivator;

        public DebbyControllerFactory(
            IServiceProvider serviceProvider,
            ITypeActivator typeActivator,
            IControllerActivator controllerActivator)
        {
            _serviceProvider = serviceProvider;
            _typeActivator = typeActivator;
            _controllerActivator = controllerActivator;
        }


        public object CreateController(ActionContext actionContext)
        {
            Type controllerType;

            var controllerActionDescriptor = actionContext.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null &&
                controllerActionDescriptor.ControllerDescriptor.ControllerTypeInfo.ContainsGenericParameters)
            {
                var entityName = actionContext.RouteData.Values["entityName"].ToString();
                var genericType = DebbyAdmin.Entities.FirstOrDefault(x => x.Name == entityName) ?? typeof (object);

                controllerType = typeof(GenericController<>).MakeGenericType(genericType);
            }
            else
            {
                var actionDescriptor = actionContext.ActionDescriptor as ControllerActionDescriptor;
                if (actionDescriptor == null)
                {
                    throw new ArgumentException(
                        string.Format("The action descriptor must be of type '{0}'",
                            typeof(ControllerActionDescriptor)),
                        "actionContext");
                }

                controllerType = actionDescriptor.ControllerDescriptor.ControllerTypeInfo.AsType();
            }

            var controller = _typeActivator.CreateInstance(
                _serviceProvider,
                controllerType);

            _controllerActivator.Activate(controller, actionContext);

            return controller;
        }

        public void ReleaseController(object controller)
        {
            var disposableController = controller as IDisposable;

            disposableController?.Dispose();
        }
    }
}