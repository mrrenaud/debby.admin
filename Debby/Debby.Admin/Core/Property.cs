using System;
using System.Reflection;

namespace Debby.Admin.Core
{
    public class Property
    {
        private Entity entity;
        private PropertyInfo property;

        public Property(Entity entity, PropertyInfo property)
        {
            this.entity = entity;
            this.property = property;


            Name = property.Name;
            PropertyType = property.PropertyType;
        }

        internal string GetFieldType()
        {
            var field = FieldTypes.TextBox;
            if (PropertyType == typeof(string))
            {
                field = FieldTypes.TextBox;
            }

            return Enum.GetName(typeof(FieldTypes), field);
        }

        public string Name { get; private set; }
        public Type PropertyType { get; private set; }
    }
}