using System;
using System.Threading.Tasks;

namespace LinksCollector.DataAccessLayer.Uow
{
    /// <summary>
    /// Unit of work.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits current changes in the unit of work
        /// </summary>
        Task<Int32> Commit();
    }
}
