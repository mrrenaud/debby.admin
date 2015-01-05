using Debby.Admin.Core.Model.Interfaces;

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