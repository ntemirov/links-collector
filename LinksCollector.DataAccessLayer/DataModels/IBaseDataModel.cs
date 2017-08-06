using System;

namespace LinksCollector.DataAccessLayer.DataModels
{
    public interface IBaseDataModel
    {
        /// <summary>
        /// Entity identifier
        /// </summary>
        Int64 Id { get; set; }
    }
}
