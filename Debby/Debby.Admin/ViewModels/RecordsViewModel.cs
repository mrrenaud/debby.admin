using Debby.Admin.Core;
using System;
using System.Collections.Generic;

namespace Debby.Admin.ViewModels
{
    public class RecordsViewModel
    {
        public IList<EntityRowData> Data { get; set; }

        public RecordsViewModel()
        {
            Data = new List<EntityRowData>();
        }
    }
}