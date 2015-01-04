using Debby.Admin.Core.Model.Interfaces;
using Debby.Admin.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Debby.Admin.Services.Interfaces
{
    public interface IEntityService
    {
        Task<RecordsViewModel> GetRecords(IEntityType entity, int page, int take);
        Task<IList<dynamic>> RetrieveRecords<T>() where T : class;
        IEntityType GetEntity(string entityName);
    }
}