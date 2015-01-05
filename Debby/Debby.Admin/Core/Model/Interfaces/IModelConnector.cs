using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Debby.Admin.Core.Model.Interfaces
{
    public interface IModelConnector
    {
        IEntityType GetEntityType(Type type);
        IEntityType GetEntityType(string entityName);
        Task<IList<dynamic>> RetrieveRecords<T>() where T : class;
    }
}