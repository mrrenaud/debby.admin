using Debby.Admin.ViewModels;
using Microsoft.AspNet.Mvc;
using System;

namespace Debby.Admin.ViewComponents
{
    public class EntityNavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var viewModel = new IndexViewModel();

            foreach (var entity in DebbyAdmin.Entities)
                viewModel.Entities.Add(entity);

            return View(viewModel);
        }
    }
}