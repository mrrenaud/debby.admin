using Debby.Admin.Core.Model.Interfaces;
using System.Collections.Generic;

namespace Debby.Admin.ViewModels
{
    public class IndexViewModel
    {
        public IList<IEntityType> Entities { get; set; }

        public IndexViewModel()
        {
            Entities = new List<IEntityType>();
        }
    }
}