using Debby.Admin.Core;
using System;

namespace Debby.Admin.ViewModels
{
    public class PropertyViewModel
    {
        public PropertyViewModel(Property property)
        {
            Property = property;
        }

        public Property Property { get; set; }

        public object Value { get; set; }
    }
}