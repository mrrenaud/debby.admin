using System;
using System.Reflection;
using Microsoft.AspNet.Mvc;

namespace Debby.Admin.Core.GenericControllers
{
    public class GenericActionDiscoveryConventions : DefaultActionDiscoveryConventions
    {
        public override bool IsController(TypeInfo typeInfo)
        {
            if (!typeInfo.IsClass ||
                typeInfo.IsAbstract ||

                // We only consider public top-level classes as controllers. IsPublic returns false for nested
                // classes, regardless of visibility modifiers.
                !typeInfo.IsPublic)
            {
                return false;
            }

            if (typeInfo.Name.Equals("Controller", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return typeInfo.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase) ||
                   typeof(Controller).GetTypeInfo().IsAssignableFrom(typeInfo);
        }
    }
}   