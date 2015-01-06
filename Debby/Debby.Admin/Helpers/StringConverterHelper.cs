using System;
using System.ComponentModel;

namespace Debby.Admin.Helpers
{
    public class StringConverterHelper
    {
        public T GetTfromString<T>(string mystring)
        {
            var foo = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                return (T)foo.ConvertFromInvariantString(mystring);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }
    }
}