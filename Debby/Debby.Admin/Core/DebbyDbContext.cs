using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using System;

namespace Debby.Admin.Core
{
    public class DebbyDbContext : DbContext
    {
        private static bool _created = false;

        public DebbyDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptions options)
        {
            options.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}