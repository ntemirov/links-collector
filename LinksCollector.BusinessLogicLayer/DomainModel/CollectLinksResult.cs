using System;
using System.Collections.Generic;

namespace LinksCollector.BusinessLogicLayer.DomainModel
{
    public class CollectLinksResult
    {
        /// <summary>
        /// Result data
        /// </summary>
        public IEnumerable<Link> Data { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public String Error { get; set; }
    }
}
