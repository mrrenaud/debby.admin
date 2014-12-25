using Debby.Admin.Core;
using System;
using System.Collections.Generic;

namespace Debby.Admin.ViewModels
{
    public class IndexViewModel
    {
        public IList<Entity> Entities { get; set; }

        public IndexViewModel()
        {
            Entities = new List<Entity>();
        }
    }
}