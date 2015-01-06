using Debby.Admin.Core;
using Debby.Admin.Core.Model.Interfaces;
using Debby.Admin.Services.Interfaces;
using Debby.Admin.ViewModels;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Debby.Admin.Core.ModelConnectors.Interfaces;

namespace Debby.Admin.Services
{
    public class EntityService : IEntityService
    {
        private IModelConnector modelConnector;

        public EntityService(IModelConnector modelConnector)
        {
            this.modelConnector = modelConnector;
        }

        public Task<dynamic> AddEntity(string entityName, dynamic data)
        {
            var entity = modelConnector.GetEntityType(entityName); ;

            MethodInfo method = modelConnector.GetType().GetMethod("AddRecord");
            method = method.MakeGenericMethod(entity.Type);
            return (Task<dynamic>)method.Invoke(modelConnector, new object[] { data });
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

            return recordsViewModel;
        }
    }
}