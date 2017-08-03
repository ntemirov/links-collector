using LinksCollector.BusinessLogicLayer.DomainModel;
using LinksCollector.DataAccessLayer.DataModels;
using LinksCollector.DataAccessLayer.Repositories;
using LinksCollector.DataAccessLayer.Uow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinksCollector.BusinessLogicLayer.Services.Implementations
{
    public class RequestServiceImpl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        public RequestServiceImpl(IRequestRepository requestRepository, IUnitOfWork uow)
        {
            _requestRepository = requestRepository;
            _uow = uow;
        }

        public Task<Int32> Create(Request contact)
        {
            _requestRepository.Add(new RequestDataModel
            {
                Url = contact.Url,
                RequestDate = contact.RequestDate,
                HyperlinksCount = contact.HyperlinksCount,
                RequestProcessingTime = contact.RequestProcessingTime
            });

            return _uow.Commit();
        }

        private readonly IRequestRepository _requestRepository;
        private readonly IUnitOfWork _uow;
    }
}
