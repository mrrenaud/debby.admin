using System;
using System.Collections.Generic;

namespace Debby.Admin.Core.Model.Interfaces
{
    public interface IModelConnector
    {
        IEntityType GetEntityType(Type type);
        IEntityType GetEntityType(string entityName);
    }
}