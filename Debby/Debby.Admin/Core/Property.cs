using Debby.Admin.Core.Model.Interfaces;
using System;

namespace Debby.Admin.Core
{
    public class Property : IProperty
    {
        private IEntityType entity;

        public string Name { get; private set; }
        public Type PropertyType { get; private set; }
        public bool IsNullable { get; internal set; }
        public bool IsReadOnly { get; internal set; }

        public Property(IEntityType entity, string name, Type propertyType)
        {
            this.entity = entity;
            this.Name = name;
            this.PropertyType = propertyType;
        }
    }
}