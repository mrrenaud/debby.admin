using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Debby.Admin.Core
{
    public class Entity
    {
        private Type Type;

        public Entity(Type type)
        {
            Type = type;
            Name = Type.Name;

            Properties = type.GetProperties().Select(x => new Property(this, x)).ToList();
        }

        public string Name { get; private set; }
        public List<Property> Properties { get; private set; }
    }
}