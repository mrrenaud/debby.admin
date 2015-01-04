using Debby.Admin.Services.Interfaces;
using Debby.Admin.ViewModels;
using Microsoft.AspNet.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Debby.Admin.Controllers
{
    public class DebbyAdminController : Controller
    {
        private IEntityService entityService;

        public DebbyAdminController(IEntityService entityService)
        {
            this.entityService = entityService;
        }

        public ViewResult Index()
        {
            var viewModel = new IndexViewModel();

            foreach (var entity in DebbyAdmin.Entities)
                viewModel.Entities.Add(entityService.GetEntity(entity.Name));

            return View(viewModel);
        }

        public async Task<ViewResult> List(string entityName)
        {
            var entity = entityService.GetEntity(entityName);
            var pagedRecords = await entityService.GetRecords(entity, 1, 20);

            var listViewModel = new ListViewModel()
            {
                Entity = entity,
                Records = pagedRecords
            };

            return View("List", listViewModel);
        }

        public ViewResult Create(string entityName)
        {
            var entity = entityService.GetEntity(entityName);

            if (entity == null)
                return View("notfound");

            var createViewModel = new CreateViewModel(entity);

            return View("Create", createViewModel);
        }
    }
}