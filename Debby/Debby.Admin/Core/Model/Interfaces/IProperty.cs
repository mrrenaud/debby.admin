﻿using System;

namespace Debby.Admin.Core.Model.Interfaces
{
    public interface IProperty
    {
        string Name { get; }

        string GetFieldType();
    }
}