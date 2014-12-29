using Debby.Admin.ViewModels;
using Microsoft.AspNet.Mvc;
using System;

namespace Debby.Admin.ViewComponents
{
    public class EntityNavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string entityName = "")
        {
            var viewModel = new EntityNavigationViewModel();

            foreach (var entity in DebbyAdmin.Entities)
                viewModel.Entities.Add(entity);

            viewModel.CurrentEntityName = entityName;

            return View(viewModel);
        }
    }
}