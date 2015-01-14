using Debby.Admin.Core.Extensions;
using Debby.Admin.Core.Model;
using Debby.Admin.Core.Model.Interfaces;
using Debby.Admin.Core.ModelConnectors.Interfaces;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debby.Admin.Core.ModelConnectors
{
    public class EFModelConnector<TContext> : IModelConnector where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly Microsoft.Data.Entity.Metadata.IModel _model;

        public EFModelConnector(TContext context)
        {
            _context = context;
            _model = context.Model;
        }

        public IEntityType GetEntityType(string entityName)
        {
            var entity = DebbyAdmin.Entities.FirstOrDefault(e => e.Name == entityName);
            if (entity == null)
                throw new ArgumentException(
                    String.Format("The provided Entity Name doesn't exist : {0}", entityName));

            return GetEntityType(entity);
        }

        public IEntityType GetEntityType(Type type)
        {
            var entityType = new EntityType(type);

            var efEntityType = _model.GetEntityType(type);
            foreach (var prop in efEntityType.Properties)
            {
                var property = new Property(entityType, prop.Name, prop.PropertyType)
                {
                    IsNullable = prop.IsNullable,
                    IsReadOnly = prop.IsReadOnly
                };

                entityType.AddProperty(property);
            }

            return entityType;
        }

        public async Task<IList<dynamic>> RetrieveRecords<T>() where T : class
        {
            var dbSet = _context.Set<T>();
            var entities = await dbSet.ToListAsync();

            return entities.Cast<dynamic>().ToList();
        }

        public async Task<dynamic> AddRecord<T>(IDictionary<string, object> data) where T : class
        {
            var obj = data.FromDynamic<T>();

            await _context.Set<T>().AddAsync(obj);

            var result = await _context.SaveChangesAsync();

            return obj;
        }
    }
}