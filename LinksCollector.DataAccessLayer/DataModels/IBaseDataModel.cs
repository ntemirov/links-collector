using System;

namespace LinksCollector.DataAccessLayer.DataModels
{
    public interface IBaseDataModel
    {
        /// <summary>
        /// Entity identifier
        /// </summary>
        Int64 Id { get; set; }

        /// <summary>
        /// Entity creation date and time
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Entity update date and time
        /// </summary>
        DateTimeOffset? UpdatedAt { get; set; }
    }
}
