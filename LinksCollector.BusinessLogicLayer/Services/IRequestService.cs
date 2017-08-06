using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using LinksCollector.BusinessLogicLayer.DomainModel;

namespace LinksCollector.BusinessLogicLayer.Services
{
    public interface IRequestService
    {
        /// <summary>
        /// Create new request
        /// </summary>
        /// <param name="request"></param>
        Task<Int32> Create(Request request);

        /// <summary>
        /// Create new request
        /// </summary>
        /// <param name="contact"></param>
        IEnumerable<Request> Find(Int32 skip, Int32 limit, String urlTerm);

        /// <summary>
        /// Update new request
        /// </summary>
        /// <param name="request"></param>
        Task<Int32> SetProcessingTime(Request request);

        /// <summary>
        /// Delete new request
        /// </summary>
        /// <param name="request"></param>
        Task<Int32> Delete(Int64 id);
    }
}
