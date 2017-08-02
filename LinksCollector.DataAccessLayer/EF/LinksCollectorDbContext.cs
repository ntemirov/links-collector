using Microsoft.EntityFrameworkCore;

using LinksCollector.DataAccessLayer.Configurations;

namespace LinksCollector.DataAccessLayer.EF
{
    public class LinksCollectorDbContext : DbContext
    {
        public LinksCollectorDbContext() : base() { }

        public LinksCollectorDbContext(DbContextOptions<LinksCollectorDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new RequestDataModelMap());
        }
    }
}
