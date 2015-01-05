using Debby.Admin.Core.Model.Interfaces;
using Debby.Admin.ViewModels;
using System.Threading.Tasks;

namespace Debby.Admin.Services.Interfaces
{
    public interface IEntityService
    {
        Task<RecordsViewModel> GetRecords(IEntityType entity, int page, int take);
        IEntityType GetEntity(string entityName);
    }
}