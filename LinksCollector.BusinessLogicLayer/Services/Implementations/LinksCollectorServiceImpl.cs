using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using LinksCollector.DataAccessLayer.DataModels;
using LinksCollector.BusinessLogicLayer.DomainModel;
using LinksCollector.DataAccessLayer.Repositories;
using LinksCollector.DataAccessLayer.Uow;

namespace LinksCollector.BusinessLogicLayer.Services.Implementations
{
    public class LinksCollectorServiceImpl : ILinksCollectorService
    {
        public LinksCollectorServiceImpl(IRequestRepository requestRepository, IUnitOfWork uow)
        {
            _requestRepository = requestRepository;
            _uow = uow;
        }

        public async Task<CollectLinksResult> CollectLinks(String url)
        {
            var request = new RequestDataModel
            {
                Url = url,
                RequestDate = DateTime.Now
            };

            _requestRepository.Add(request);
            await _uow.Commit();

            var hc = new HttpClient();
            try
            {
                using (var response = await hc.GetAsync(url))
                {
                    // read answer in non-blocking way
                    var stream = await response.Content.ReadAsStreamAsync();
                    var document = new HtmlDocument();
                    document.Load(stream);

                    var linkNodes = document.DocumentNode.SelectNodes("//a[@href]");

                    if (linkNodes == null)
                    {
                        return null;
                    }

                    var links = linkNodes.Select(node =>
                    {
                        return new Link
                        {
                            RequestId = request.Id,
                            Text = node.InnerText,
                            Url = node.Attributes.FirstOrDefault(attr => attr.Name == "href").Value
                        };
                    });

                    var groupedLinks = links.GroupBy(link => link.Url).Select(lnks =>
                    {
                        lnks.ElementAt(0).Count = lnks.Count();
                        return lnks.ElementAt(0);
                    });

                    request.HyperlinksCount = links.Count();
                    _requestRepository.Update(request);
                    var x = await _uow.Commit();

                    return new CollectLinksResult
                    {
                        Data = groupedLinks,
                        Error = null
                    };
                }
            }
            catch (Exception)
            {
                return new CollectLinksResult
                {
                    Data = null,
                    Error = "An error has occurred. Verify that the address you entered is correct and try again."
                };
            }
        }

        private readonly IRequestRepository _requestRepository;
        private readonly IUnitOfWork _uow;
    }
}
