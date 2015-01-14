using System.Collections.Generic;
using System.Linq;
using Debby.Admin.Core;
using Debby.Admin.Core.Model.Interfaces;

namespace Debby.Admin.ViewModels
{
    public class RecordsViewModel
    {
        public IList<EntityRowData> Data { get; set; }
        public IEntityType EntityType { get; internal set; }

        public RecordsViewModel()
        {
            Data = new List<EntityRowData>();
        }

        public RecordsViewModel(IEntityType entityType, IEnumerable<dynamic> data)
        {
            EntityType = entityType;

            Data = data.Select(x => new EntityRowData(x)).ToList();
        }
    }
}