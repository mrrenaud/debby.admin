using Debby.Admin.Core.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<IList<dynamic>> RetrieveRecords<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}