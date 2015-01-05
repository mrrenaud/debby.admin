using Debby.Admin.Services;
using Debby.Admin.Services.Interfaces;
using Debby.Admin.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Debby.Admin.Core.ModelBinders
{
    public class DynamicModelBinder : IModelBinder
    {
        private IContextAccessor<ActionContext> context;
        private IEntityService entityService;

        public DynamicModelBinder(IContextAccessor<ActionContext> context,
            IEntityService entityService)
        {
            this.entityService = entityService;
            this.context = context;
        }

        public async Task<bool> BindModelAsync(ModelBindingContext bindingContext)
        {
            object entityName = "";
            if (!context.Value.RouteData.Values.TryGetValue("entityName", out entityName))
                return false;

            var type = DebbyAdmin.Entities.FirstOrDefault(t => t.Name == (string)entityName);
            if (type == null)
                return false;

            var entity = entityService.GetEntity((string)entityName);

            var postCreateViewModel = new PostCreateViewModel();
            postCreateViewModel.EntityName = entity.Name;

            foreach (var prop in entity.Properties)
            {
                postCreateViewModel.Data.Add(prop.Name,
                    await bindingContext.ValueProvider.GetValueAsync(prop.Name));
            }

            bindingContext.Model = postCreateViewModel;

            return true;
        }
    }
}