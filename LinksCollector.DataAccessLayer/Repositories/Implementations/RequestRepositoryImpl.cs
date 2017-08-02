using LinksCollector.DataAccessLayer.DataModels;
using LinksCollector.DataAccessLayer.EF;

namespace LinksCollector.DataAccessLayer.Repositories.Implementations
{
    /// <summary>
    /// Default implementation of <see cref="IRequestRepository"/>
    /// </summary>
    class RequestRepositoryImpl : RepositoryBase<RequestDataModel>, IRequestRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactsRepositoryImpl"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public RequestRepositoryImpl(LinksCollectorDbContext dbContext) : base(dbContext) { }
    }
}
