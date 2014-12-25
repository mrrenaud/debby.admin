using System;
using System.Reflection;

namespace Debby.Admin.Core
{
    public class Property
    {
        private Entity entity;
        private PropertyInfo x;

        public Property(Entity entity, PropertyInfo x)
        {
            this.entity = entity;
            this.x = x;
        }
    }
}