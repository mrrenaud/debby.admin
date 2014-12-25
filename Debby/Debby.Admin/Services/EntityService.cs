using Debby.Admin.Core;
using Debby.Admin.ViewModels;

namespace Debby.Admin.Services
{
    public class EntityService
    {
        public RecordsViewModel GetRecords(Entity entity, int page, int take)
        {
            return new RecordsViewModel();
        }
    }
}