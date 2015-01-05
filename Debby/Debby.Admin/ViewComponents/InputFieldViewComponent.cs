using Debby.Admin.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using Debby.Admin.Core.Extensions;

namespace Debby.Admin.ViewComponents
{
    public class InputFieldViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PropertyViewModel property)
        {
            return View(property.Property.GetFieldType(), property);
        }
    }
}