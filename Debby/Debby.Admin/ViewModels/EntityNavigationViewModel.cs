using Debby.Admin.Core;
using System;
using System.Collections.Generic;

namespace Debby.Admin.ViewModels
{
    public class EntityNavigationViewModel
    {
        public IList<Entity> Entities { get; set; }

        public EntityNavigationViewModel()
        {
            Entities = new List<Entity>();
        }

        public string CurrentEntityName { get; set; }
    }
}