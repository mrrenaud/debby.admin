using Debby.Admin.Services;
using Debby.Admin.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Linq;

namespace Debby.Admin.Controllers
{
    public class DebbyAdminController : Controller
    {
        public ViewResult Index()
        {
            var viewModel = new IndexViewModel();

            foreach (var entity in DebbyAdmin.Entities)
                viewModel.Entities.Add(entity);

            return View(viewModel);
        }

        public ViewResult List(string entityName)
        {
            var entity = DebbyAdmin.Entities.FirstOrDefault(e => string.Compare(e.Name, entityName, true) == 0);

            if (entity == null)
                return View("notfound");

            var pagedRecords = new EntityService().GetRecords(entity, 1, 20);

            var listViewModel = new ListViewModel()
            {
                Entity = entity,
                Records = pagedRecords
            };

            return View("List", listViewModel);
        }
    }
}