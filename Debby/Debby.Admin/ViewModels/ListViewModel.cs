using Debby.Admin.Core.Model.Interfaces;

namespace Debby.Admin.ViewModels
{
    public class ListViewModel
    {
        public IEntityType Entity { get; set; }

        public RecordsViewModel Records { get; set; }
    }
}