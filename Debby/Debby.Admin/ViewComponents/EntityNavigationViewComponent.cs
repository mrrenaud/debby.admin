using Debby.Admin.Services.Interfaces;
using Debby.Admin.ViewModels;
using Microsoft.AspNet.Mvc;
using System;

namespace Debby.Admin.ViewComponents
{
    public class EntityNavigationViewComponent : ViewComponent
    {
        private IEntityService entityService;

        public EntityNavigationViewComponent(IEntityService entityService)
        {
            this.entityService = entityService;
        }

        public IViewComponentResult Invoke(string entityName = "")
        {
            var viewModel = new EntityNavigationViewModel();

            foreach (var entity in DebbyAdmin.Entities)
                viewModel.Entities.Add(entityService.GetEntity(entity.Name));

            viewModel.CurrentEntityName = entityName;

            return View(viewModel);
        }
    }
}