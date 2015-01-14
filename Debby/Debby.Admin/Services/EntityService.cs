using System.Threading.Tasks;
using Debby.Admin.Core.Model.Interfaces;
using Debby.Admin.Core.ModelConnectors.Interfaces;
using Debby.Admin.Services.Interfaces;
using Debby.Admin.ViewModels;

namespace Debby.Admin.Services
{
    public class EntityService : IEntityService
    {
        private readonly IModelConnector _modelConnector;

        public EntityService(IModelConnector modelConnector)
        {
            _modelConnector = modelConnector;
        }

        public IEntityType GetEntity(string entityName)
        {
            return _modelConnector.GetEntityType(entityName);
        }

        public async Task<RecordsViewModel> GetRecords<T>(int page, int take) where T : class
        {
            var data = await _modelConnector.RetrieveRecords<T>();
            var entityType = GetEntity(typeof (T).Name);

            return new RecordsViewModel(entityType, data);
        }

        public Task<dynamic> AddEntity<T>(dynamic data) where T : class
        {
            return _modelConnector.AddRecord<T>(data);
        }
    }
}