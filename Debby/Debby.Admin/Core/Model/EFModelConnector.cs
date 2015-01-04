using Debby.Admin.Core.Model.Interfaces;
using Microsoft.Data.Entity;
using System;
using System.Linq;

namespace Debby.Admin.Core.Model
{
    public class EFModelConnector<TContext> : IModelConnector where TContext : DbContext
    {
        private Microsoft.Data.Entity.Metadata.IModel model;

        public EFModelConnector(TContext context)
        {
            this.model = context.Model;
        }

        public IEntityType GetEntityType(string entityName)
        {
            var entity = DebbyAdmin.Entities.FirstOrDefault(e => e.Name == entityName);
            if (entity == null)
                throw new ArgumentException("The provided Entity Name doesn't exist : {0}", entityName);

            return GetEntityType(entity);
        }

        public IEntityType GetEntityType(Type type)
        {
            var entityType = new EntityType(type);

            var efEntityType = model.GetEntityType(type);
            foreach (var prop in efEntityType.Properties)
            {
                var property = new Property(entityType, prop.Name, prop.PropertyType);
                property.IsNullable = prop.IsNullable;
                property.IsReadOnly = prop.IsReadOnly;
                entityType.AddProperty(property);
            }

            return entityType;
        }
    }
}