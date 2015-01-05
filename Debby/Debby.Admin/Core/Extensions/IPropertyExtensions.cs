using Debby.Admin.Core.Model.Interfaces;
using System;

namespace Debby.Admin.Core.Extensions
{
    public static class IPropertyExtensions
    {
        public static string GetFieldType(this IProperty property)
        {
            var field = FieldTypes.TextBox;
            if (property.PropertyType == typeof(string))
            {
                field = FieldTypes.TextBox;
            }

            return Enum.GetName(typeof(FieldTypes), field);
        }
    }
}