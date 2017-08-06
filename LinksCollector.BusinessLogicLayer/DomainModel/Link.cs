using System;

namespace LinksCollector.BusinessLogicLayer.DomainModel
{
    public class Link
    {
        /// <summary>
        /// The request id
        /// </summary>
        public Int64 RequestId { get; set; }

        /// <summary>
        /// The link text
        /// </summary>
        public String Text { get; set; }

        /// <summary>
        /// The link url
        /// </summary>
        public String Url { get; set; }

        /// <summary>
        /// Number of repetitions of the link on the page
        /// </summary>
        public Int32 Count { get; set; }
    }
}
