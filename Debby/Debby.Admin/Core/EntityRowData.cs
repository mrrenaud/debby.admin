using System;

namespace Debby.Admin.Core
{
    public class EntityRowData
    {
        private dynamic Data { get; set; }

        public EntityRowData(dynamic data)
        {
            Data = data;
        }
    }
}