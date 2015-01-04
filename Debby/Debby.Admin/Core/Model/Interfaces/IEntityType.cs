using System;
using System.Collections.Generic;

namespace Debby.Admin.Core.Model.Interfaces
{
    public interface IEntityType
    {
        string Name { get; }

        string SimpleName { get; }

        Type Type { get; }

        IReadOnlyList<IProperty> Properties { get; }

        void AddProperty(IProperty property);
    }
}