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
        /// Entity creation date
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Entity update date
        /// </summary>
        DateTimeOffset? UpdatedAt { get; set; }
    }
}
