using Debby.Admin.Core;
using Debby.Admin.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Debby.Admin.Services.Interfaces
{
    public interface IEntityService
    {
        Task<RecordsViewModel> GetRecords(Entity entity, int page, int take);
        Task<IList<dynamic>> RetrieveRecords<T>() where T : class;
    }
}