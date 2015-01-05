using Debby.Admin.Core.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Debby.Admin.Core.ModelConnectors.Interfaces
{
    public interface IModelConnector
    {
        IEntityType GetEntityType(Type type);
        IEntityType GetEntityType(string entityName);
        Task<IList<dynamic>> RetrieveRecords<T>() where T : class;
        Task<dynamic> AddRecord<T>(dynamic data) where T : class;
    }
}