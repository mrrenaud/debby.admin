using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;

namespace Debby.Admin.Core.GenericControllers
{
    public class GenericActionInvoker : FilterActionInvoker
    {
        private readonly IControllerFactory _controllerFactory;
        private readonly IControllerActionArgumentBinder _argumentBinder;
        private static readonly Type TaskGenericType = typeof(Task<>);

        public GenericActionInvoker(
            ActionContext actionContext,
            INestedProviderManager<FilterProviderContext> filterProvider,
            IControllerFactory controllerFactory,
            IControllerActionArgumentBinder argumentBinder)
            : base(actionContext, filterProvider)
        {
            _controllerFactory = controllerFactory;
            _argumentBinder = argumentBinder;
        }

        public async override Task InvokeAsync()
        {
            var controller = _controllerFactory.CreateController(ActionContext);

            try
            {
                ActionContext.Controller = controller;
                await base.InvokeAsync();
            }
            finally
            {
                _controllerFactory.ReleaseController(ActionContext.Controller);
            }
        }

        protected override async Task<IActionResult> InvokeActionAsync(ActionExecutingContext actionExecutingContext)
        {
            var controllerActionDescriptor = (ControllerActionDescriptor)actionExecutingContext.ActionDescriptor;

            var actionMethodInfo = controllerActionDescriptor.MethodInfo;

            actionMethodInfo = actionExecutingContext.Controller.GetType()
                .GetMethod(actionMethodInfo.Name, controllerActionDescriptor.Parameters.Select(x => x.ParameterType).ToArray());

            var actionReturnValue = await ControllerActionExecutor.ExecuteAsync(
                actionMethodInfo,
                ActionContext.Controller,
                actionExecutingContext.ActionArguments);

            var actionResult = CreateActionResult(
                actionMethodInfo.ReturnType,
                actionReturnValue);

            return actionResult;
        }

        protected override Task<IDictionary<string, object>> GetActionArgumentsAsync(ActionContext context)
        {
            return _argumentBinder.GetActionArgumentsAsync(context);
        }

        // Copied from ControllerActionInvoker (Can't call it as internal there).
        private static IActionResult CreateActionResult(Type declaredReturnType, object actionReturnValue)
        {
            // optimize common path
            var actionResult = actionReturnValue as IActionResult;
            if (actionResult != null)
            {
                return actionResult;
            }

            if (declaredReturnType == typeof(void) ||
                declaredReturnType == typeof(Task))
            {
                return new ObjectResult(null)
                {
                    // Treat the declared type as void, which is the unwrapped type for Task.
                    DeclaredType = typeof(void)
                };
            }

            Type actualReturnType = null;

            if (declaredReturnType.GetTypeInfo().IsGenericType && !declaredReturnType.GetTypeInfo().IsGenericTypeDefinition)
            {
                var genericTypeDefinition = declaredReturnType.GetGenericTypeDefinition();
                var genericArguments = declaredReturnType.GetGenericArguments();
                if (genericArguments.Length == 1 && TaskGenericType == genericTypeDefinition)
                {
                    // Only Return if there is a single argument.
                    actualReturnType = genericArguments[0];
                }
            }

            if (actualReturnType == null)
                actualReturnType = declaredReturnType;

            if (actionReturnValue == null && typeof(IActionResult).IsAssignableFrom(actualReturnType))
            {
                throw new InvalidOperationException(string.Format("Cannot return null from an action method with a return type of '{0}'.", actualReturnType));
            }

            return new ObjectResult(actionReturnValue)
            {
                DeclaredType = actualReturnType
            };
        }
    }
}