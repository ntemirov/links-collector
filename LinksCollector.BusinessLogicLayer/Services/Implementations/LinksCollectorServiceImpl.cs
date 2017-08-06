using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using LinksCollector.BusinessLogicLayer.DomainModel;

namespace LinksCollector.BusinessLogicLayer.Services.Implementations
{
    public class LinksCollectorServiceImpl : ILinksCollectorService
    {
        public async Task<CollectLinksResult> CollectLinks(String url)
        {
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
                            Text = node.InnerText,
                            Url = node.Attributes.FirstOrDefault(attr => attr.Name == "href").Value
                        };
                    });

                    return new CollectLinksResult{
                        Data = links,
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
    }
}
