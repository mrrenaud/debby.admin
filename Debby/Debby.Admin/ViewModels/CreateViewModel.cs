using Debby.Admin.Core;
using Debby.Admin.Core.Model.Interfaces;
using Microsoft.AspNet.Routing;
using System.Collections.Generic;

namespace Debby.Admin.ViewModels
{
    public class CreateViewModel
    {
        public CreateViewModel(IEntityType entity) :
            this(entity, new { })
        {
        }

        public CreateViewModel(IEntityType entity, object obj)
        {
            Entity = entity;
            Values = new RouteValueDictionary(obj);

            Properties = new List<PropertyViewModel>();

            foreach (var prop in entity.Properties)
            {
                var propViewModel = new PropertyViewModel(prop);
                if (Values.ContainsKey(prop.Name))
                {
                    propViewModel.Value = Values[prop.Name];
                }
                Properties.Add(propViewModel);
            }
        }

        public IEntityType Entity { get; internal set; }
        public List<PropertyViewModel> Properties { get; private set; }
        public RouteValueDictionary Values { get; set; }
    }
}