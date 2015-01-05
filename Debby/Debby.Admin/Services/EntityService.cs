using Debby.Admin.Core;
using Debby.Admin.Core.Model.Interfaces;
using Debby.Admin.Services.Interfaces;
using Debby.Admin.ViewModels;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Debby.Admin.Services
{
    public class EntityService : IEntityService
    {
        private IModelConnector modelConnector;

        public EntityService(IModelConnector modelConnector)
        {
            this.modelConnector = modelConnector;
        }

        public IEntityType GetEntity(string entityName)
        {
            return modelConnector.GetEntityType(entityName);
        }

        public async Task<RecordsViewModel> GetRecords(IEntityType entity, int page, int take)
        {
            var recordsViewModel = new RecordsViewModel();

            MethodInfo method = modelConnector.GetType().GetMethod("RetrieveRecords");
            method = method.MakeGenericMethod(entity.Type);
            var data = await (Task<IList<dynamic>>)method.Invoke(modelConnector, new object[0]);

            recordsViewModel.EntityType = modelConnector.GetEntityType(entity.Type);

            foreach (var row in data)
            {
                recordsViewModel.Data.Add(new EntityRowData(row));
            }

            return new RecordsViewModel();
        }

    }
}