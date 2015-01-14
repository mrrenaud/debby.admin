using System;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;

namespace Debby.Admin.Core.GenericControllers
{
    public class GenericControllerActionInvokerProvider : IActionInvokerProvider
    {
        private readonly IControllerFactory _controllerFactory;
        private readonly INestedProviderManager<FilterProviderContext> _filterProvider;
        private readonly IControllerActionArgumentBinder _argumentBinder;

        public GenericControllerActionInvokerProvider(
            IControllerFactory controllerFactory,
            INestedProviderManager<FilterProviderContext> filterProvider,
            IControllerActionArgumentBinder argumentBinder)
        {
            _controllerFactory = controllerFactory;
            _filterProvider = filterProvider;
            _argumentBinder = argumentBinder;
        }

        public int Order => DefaultOrder.DefaultFrameworkSortOrder;

        public void Invoke(ActionInvokerProviderContext context, Action callNext)
        {
            var actionDescriptor = context.ActionContext.ActionDescriptor as ControllerActionDescriptor;

            if (actionDescriptor != null)
            {
                context.Result = new GenericActionInvoker(
                                    context.ActionContext,
                                    _filterProvider,
                                    _controllerFactory,
                                    _argumentBinder);
            }

            callNext();
        }

    }
}