using Debby.Admin.Core;
using Debby.Admin.Core.Model;
using Debby.Admin.Core.Model.Interfaces;
using System;
using System.Collections.Generic;

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
    }
}