using Debby.Admin.Core;
using Debby.Admin.Core.Model.Interfaces;
using System;

namespace Debby.Admin.ViewModels
{
    public class PropertyViewModel
    {
        public PropertyViewModel(IProperty property)
        {
            Property = property;
        }

        public IProperty Property { get; set; }

        public object Value { get; set; }
    }
}