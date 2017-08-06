using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using LinksCollector.BusinessLogicLayer.DomainModel;

namespace LinksCollector.BusinessLogicLayer.Services
{
    public interface ILinksCollectorService
    {
        /// <summary>
        /// Extract all links from the page
        /// </summary>
        /// <param name="url">The page url</param>
        /// <returns>All page links</returns>
        Task<CollectLinksResult> CollectLinks(String url);
    }
}
