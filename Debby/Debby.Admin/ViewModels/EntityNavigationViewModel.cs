using Debby.Admin.Core;
using Debby.Admin.Core.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace Debby.Admin.ViewModels
{
    public class EntityNavigationViewModel
    {
        public IList<IEntityType> Entities { get; set; }

        public EntityNavigationViewModel()
        {
            Entities = new List<IEntityType>();
        }

        public string CurrentEntityName { get; set; }
    }
}