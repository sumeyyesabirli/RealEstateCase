using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateCase.Business.Futures.Commands.AdvertisementType.AddAdvertisementType;
using RealEstateCase.Business.Futures.Queries.AdvertisementType.GetAllAdvertisementType;
using RealEstateCase.Core.Controllers;

namespace RealEstateCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementTypeController : BaseController
    {
        public AdvertisementTypeController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddAdvertisementType([FromBody] AddAdvertisementTypeCommandRequestModel requestModel, CancellationToken cancellationToken)
            => HandleResponse(await _mediator.Send(requestModel, cancellationToken));

        [HttpGet]
        public async Task<IActionResult> GetAdvertisementTypeList([FromQuery] GetAllAdvertisementTypeQueryRequestModel requestModel, CancellationToken cancellationToken)
           => HandleResponse(await _mediator.Send(requestModel, cancellationToken));
    }
}
