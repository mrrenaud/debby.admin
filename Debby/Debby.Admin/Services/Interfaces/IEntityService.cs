using Debby.Admin.Core.Model.Interfaces;
using Debby.Admin.ViewModels;
using System.Threading.Tasks;

namespace Debby.Admin.Services.Interfaces
{
    public interface IEntityService
    {
        Task<RecordsViewModel> GetRecords<T>(int page, int take) where T : class;
        IEntityType GetEntity(string entityName);
        Task<dynamic> AddEntity<T>(dynamic data) where T : class;
    }
}