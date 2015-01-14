using System.Threading.Tasks;
using Debby.Admin.Services.Interfaces;
using Debby.Admin.ViewModels;
using Microsoft.AspNet.Mvc;

namespace Debby.Admin.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IEntityService _entityService;

        public GenericController(IEntityService entityService)
        {
            _entityService = entityService;
        }

        public ActionResult Index()
        {
            var viewModel = new IndexViewModel();

            foreach (var entity in DebbyAdmin.Entities)
                viewModel.Entities.Add(_entityService.GetEntity(entity.Name));

            return View("../DebbyAdmin/Index", viewModel);
        }

        public async Task<ActionResult> List()
        {
            var pagedRecords = await _entityService.GetRecords<T>(1, 20);

            var entity = _entityService.GetEntity(typeof(T).Name);

            var listViewModel = new ListViewModel
            {
                Entity = entity,
                Records = pagedRecords
            };

            return View("../DebbyAdmin/List", listViewModel);
        }

        public ActionResult Create()
        {
            var entity = _entityService.GetEntity(typeof(T).Name);

            if (entity == null)
                return RedirectToAction("Index");

            var createViewModel = new CreateViewModel(entity);

            return View("../DebbyAdmin/Create", createViewModel);
        }

        [HttpPost]
        public ActionResult Create(PostCreateViewModel viewModel)
        {
            _entityService.AddEntity<T>(viewModel.Data);

            return RedirectToAction("List", new { entityName = viewModel.EntityName });
        }
    }
}