using System;
using System.Collections.Generic;
using System.Text;

namespace LinksCollector.BusinessLogicLayer.DomainModel
{
    public class Request
    {
        /// <summary>
        /// The request id
        /// </summary>
        public Int64 Id { get; set; }

        /// <summary>
        /// The request url
        /// </summary>
        public String Url { get; set; }

        /// <summary>
        /// Date and time of the request
        /// </summary>
        public DateTimeOffset RequestDate { get; set; }

        /// <summary>
        /// Count of hyperlinks on the requested page
        /// </summary>
        public Int32 HyperlinksCount { get; set; }

        /// <summary>
        /// The request processing time in microseconds
        /// </summary>
        public Double RequestProcessingTime { get; set; }
    }
}
