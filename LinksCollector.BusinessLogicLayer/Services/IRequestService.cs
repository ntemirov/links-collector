using System;
using System.Threading.Tasks;

using LinksCollector.BusinessLogicLayer.DomainModel;

namespace LinksCollector.BusinessLogicLayer.Services
{
    public interface IRequestService
    {
        /// <summary>
        /// Create new request
        /// </summary>
        /// <param name="contact"></param>
        Task<Int32> Create(Request request);
    }
}
