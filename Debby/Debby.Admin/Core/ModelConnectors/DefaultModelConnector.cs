using Debby.Admin.Core.Model.Interfaces;
using Debby.Admin.Core.ModelConnectors.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Debby.Admin.Core.ModelConnectors
{
    public class DefaultModelConnector : IModelConnector
    {
        public Task<dynamic> AddRecord<T>(dynamic data) where T : class
        {
            throw new NotImplementedException();
        }

        public IEntityType GetEntityType(string entityName)
        {
            throw new NotImplementedException();
        }

        public IEntityType GetEntityType(Type type)
        {
            throw new NotImplementedException();
        }

        public Task<IList<dynamic>> RetrieveRecords<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}