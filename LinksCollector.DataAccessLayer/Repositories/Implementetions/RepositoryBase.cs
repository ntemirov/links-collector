using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

using LinksCollector.DataAccessLayer.EF;

namespace LinksCollector.DataAccessLayer.Repositories.Implementetions
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="aspNetCoreAngularDbContext">The db context.</param>
        protected RepositoryBase(LinksCollectorDbContext aspNetCoreAngularDbContext)
        {
            _dbContext = aspNetCoreAngularDbContext;
        }
        
        public virtual async Task<T> GetById(Int64 id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        
        public virtual IRepository<T> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return this;
        }
        
        public virtual IRepository<T> Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return this;
        }
        
        public virtual IRepository<T> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return this;
        }
        
        public virtual IQueryable<T> Query()
        {
            return _dbContext.Set<T>();
        }

        /// <summary>
        /// Current instance of the db context
        /// </summary>
        private readonly LinksCollectorDbContext _dbContext;
    }
}
