using System;
using System.Threading.Tasks;

using LinksCollector.DataAccessLayer.EF;

namespace LinksCollector.DataAccessLayer.Uow
{
    public class UnitOfWorkImpl : IUnitOfWork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkImpl"/> class.
        /// </summary>
        /// <param name="aspNetCoreAngularDbContext">The db context.</param>
        public UnitOfWorkImpl(LinksCollectorDbContext aspNetCoreAngularDbContext)
        {
            _dbContext = aspNetCoreAngularDbContext;
        }

        /// <summary>
        /// Commits current changes in the unit of work
        /// </summary>
        public async Task<Int32> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Current instance of the db context
        /// </summary>
        private readonly LinksCollectorDbContext _dbContext;
    }
}
