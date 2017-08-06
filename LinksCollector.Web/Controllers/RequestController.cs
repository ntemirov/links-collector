using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using LinksCollector.BusinessLogicLayer.DomainModel;
using LinksCollector.BusinessLogicLayer.Services;

namespace LinksCollector_Web.Controllers
{
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("[action]"), Produces("application/json")]
        public IActionResult Find(Int32 skip, Int32 limit, String urlTerm)
        {
            if (urlTerm == null)
            {
                urlTerm = "";
            }

            return Json(_requestService.Find(skip, limit, urlTerm));
        }

        [HttpPatch("[action]"), Produces("application/json")]
        public async Task<IActionResult> SetProcessingTime([FromBody]Request request)
        {
            return Json(await _requestService.SetProcessingTime(request));
        }

        [HttpDelete("[action]"), Produces("application/json")]
        public async Task<IActionResult> Delete(Int64 id)
        {
            return Json(await _requestService.Delete(id));
        }

        private readonly IRequestService _requestService;
    }
}
