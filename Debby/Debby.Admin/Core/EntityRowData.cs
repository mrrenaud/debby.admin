using System;

namespace Debby.Admin.Core
{
    public class EntityRowData
    {
        public dynamic Data { get; set; }

        public EntityRowData(dynamic data)
        {
            Data = data;
        }
    }
}