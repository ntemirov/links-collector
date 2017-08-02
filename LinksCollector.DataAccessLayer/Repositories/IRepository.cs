using System;
using System.Linq;
using System.Threading.Tasks;

namespace LinksCollector.DataAccessLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Entity from repository</returns>
        Task<T> GetById(Int64 id);

        /// <summary>
        /// Adds the specified entity into the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Current repository instance for chained operations
        /// </returns>
        IRepository<T> Add(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Current repository instance for chained operations
        /// </returns>
        IRepository<T> Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Current repository instance for chained operations
        /// </returns>
        IRepository<T> Delete(T entity);

        /// <summary>
        /// Queries this repository - provides ability to query using LINQ through entities inside repository.
        /// </summary>
        /// <returns>
        /// Entities from repository
        /// </returns>
        IQueryable<T> Query();
    }
}
