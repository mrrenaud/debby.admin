using Debby.Admin.Core.Model.Interfaces;
using System;

namespace Debby.Admin.Core.Model
{
    public class DefaultModelConnector : IModelConnector
    {
        public IEntityType GetEntityType(string entityName)
        {
            throw new NotImplementedException();
        }

        public IEntityType GetEntityType(Type type)
        {
            throw new NotImplementedException();
        }
    }
}