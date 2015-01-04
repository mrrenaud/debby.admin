using Debby.Admin.Core;
using Debby.Admin.Core.Model.Interfaces;
using Debby.Admin.Services.Interfaces;
using Debby.Admin.ViewModels;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System;

namespace Debby.Admin.Services
{
    public class EntityService<TContext> : IEntityService where TContext : DbContext
    {
        private TContext context;
        private IModelConnector modelConnector;

        public EntityService(TContext context, IModelConnector modelConnector)
        {
            this.context = context;
            this.modelConnector = modelConnector;
        }

        public IEntityType GetEntity(string entityName)
        {
            return modelConnector.GetEntityType(entityName);
        }

        public async Task<RecordsViewModel> GetRecords(Core.Model.Interfaces.IEntityType entity, int page, int take)
        {
            var recordsViewModel = new RecordsViewModel();

            MethodInfo method = typeof(EntityService<TContext>).GetMethod("RetrieveRecords");
            method = method.MakeGenericMethod(entity.Type);
            var data = await (Task<IList<dynamic>>)method.Invoke(this, new object[0]);

            recordsViewModel.EntityType = modelConnector.GetEntityType(entity.Type);

            foreach (var row in data)
            {
                recordsViewModel.Data.Add(new EntityRowData(row));
            }

            return new RecordsViewModel();
        }

        public async Task<IList<dynamic>> RetrieveRecords<T>() where T : class
        {
            var dbSet = context.Set<T>();
            var entities = await dbSet.ToListAsync();

            var data = new List<dynamic>();
            foreach (var entity in entities)
                data.Add(entity);

            return data;
        }
    }
}