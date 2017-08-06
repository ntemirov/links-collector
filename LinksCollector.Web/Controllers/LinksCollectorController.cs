using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LinksCollector.BusinessLogicLayer.Services;

namespace LinksCollector.Web.Controllers
{
    [Route("api/[controller]")]
    public class LinksCollectorController : Controller
    {
        public LinksCollectorController(ILinksCollectorService linksCollectorService)
        {
            _linksCollectorService = linksCollectorService;
        }

        [HttpGet("[action]"), Produces("application/json")]
        public async Task<IActionResult> GetLinks(String url)
        {
            return Json(await _linksCollectorService.CollectLinks(url));
        }

        private readonly ILinksCollectorService _linksCollectorService;
    }
}
