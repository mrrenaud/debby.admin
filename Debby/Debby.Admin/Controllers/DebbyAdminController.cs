using System.Threading.Tasks;
using Debby.Admin.Services.Interfaces;
using Debby.Admin.ViewModels;
using Microsoft.AspNet.Mvc;

namespace Debby.Admin.Controllers
{
    public class DebbyAdminController : Controller
    {
        private readonly IEntityService _entityService;

        public DebbyAdminController(IEntityService entityService)
        {
            _entityService = entityService;
        }

        public ViewResult Index()
        {
            var viewModel = new IndexViewModel();

            foreach (var entity in DebbyAdmin.Entities)
                viewModel.Entities.Add(_entityService.GetEntity(entity.Name));

            return View(viewModel);
        }
    }
}