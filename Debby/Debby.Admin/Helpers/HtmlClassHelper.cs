using System;

namespace Debby.Admin.Helpers
{
    public class HtmlClassHelper
    {
        public static string IsActive(string item, string activeItem)
        {
            return string.Compare(item, activeItem) == 0 ? "active" : "";
        }
    }
}