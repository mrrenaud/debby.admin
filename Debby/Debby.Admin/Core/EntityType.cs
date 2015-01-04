using Debby.Admin.Core.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Debby.Admin.Core
{
    public class EntityType : IEntityType
    {
        private List<IProperty> _properties;

        public Type Type { get; private set; }

        public string Name { get; private set; }
        public IReadOnlyList<IProperty> Properties { get { return _properties; } }

        public string SimpleName { get; set; }

        public EntityType(Type type)
        {
            Type = type;
            Name = type.Name;

            _properties = new List<IProperty>();
        }

        public void AddProperty(IProperty property)
        {
            _properties.Add(property);
        }
    }
}