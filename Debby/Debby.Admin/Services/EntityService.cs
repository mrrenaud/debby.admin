using Debby.Admin.Core;
using Debby.Admin.Services.Interfaces;
using Debby.Admin.ViewModels;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Debby.Admin.Services
{
    public class EntityService<TContext> : IEntityService where TContext : DbContext
    {
        private TContext context;

        public EntityService(TContext context)
        {
            this.context = context;
        }

        public async Task<RecordsViewModel> GetRecords(Entity entity, int page, int take)
        {
            var recordsViewModel = new RecordsViewModel();

            MethodInfo method = typeof(EntityService<TContext>).GetMethod("RetrieveRecords");
            method = method.MakeGenericMethod(entity.Type);
            var data = await (Task<IList<dynamic>>)method.Invoke(this, new object[0]);

            foreach (var row in data)
            {
                recordsViewModel.Data.Add(new EntityRowData());
            }

            return new RecordsViewModel();
        }

        public async Task<IList<dynamic>> RetrieveRecords<T>() where T : class
        {
            var dbSet = context.Set<T>();
            var entities = await dbSet.ToListAsync();

            var data = new List<dynamic>();
            foreach (var entity in entities)
                data.Add(entity);

            return data;
        }
    }
}