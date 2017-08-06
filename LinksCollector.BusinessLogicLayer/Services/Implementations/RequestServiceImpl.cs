using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LinksCollector.BusinessLogicLayer.DomainModel;
using LinksCollector.DataAccessLayer.DataModels;
using LinksCollector.DataAccessLayer.Repositories;
using LinksCollector.DataAccessLayer.Uow;

namespace LinksCollector.BusinessLogicLayer.Services.Implementations
{
    public class RequestServiceImpl : IRequestService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        public RequestServiceImpl(IRequestRepository requestRepository, IUnitOfWork uow)
        {
            _requestRepository = requestRepository;
            _uow = uow;
        }

        public Task<Int32> Create(Request request)
        {
            _requestRepository.Add(new RequestDataModel
            {
                Url = request.Url,
                RequestDate = request.RequestDate,
                HyperlinksCount = request.HyperlinksCount,
                RequestProcessingTime = request.RequestProcessingTime
            });

            return _uow.Commit();
        }

        public IEnumerable<Request> Find(Int32 skip, Int32 limit, String urlTerm = "")
        {
            return _requestRepository.Query()
                .Where(r => r.Url.Contains(urlTerm))
                .OrderByDescending(r => r.RequestDate)
                .Skip(skip).Take(limit)
                .Select(r =>
                new Request
                {
                    Id = r.Id,
                    Url = r.Url,
                    RequestDate = r.RequestDate,
                    HyperlinksCount = r.HyperlinksCount,
                    RequestProcessingTime = r.RequestProcessingTime
                }).ToArray();
        }

        public async Task<Int32> SetProcessingTime(Request request)
        {
            var req = await _requestRepository.GetById(request.Id);
            req.RequestProcessingTime = request.RequestProcessingTime;

            _requestRepository.Update(req);

            var x = await _uow.Commit();
            return x;
        }

        public async Task<Int32> Delete(Int64 id)
        {
            _requestRepository.Delete(new RequestDataModel{ Id = id });

            return await _uow.Commit();
        }

        private readonly IRequestRepository _requestRepository;
        private readonly IUnitOfWork _uow;
    }
}
