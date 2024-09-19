using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateCase.Business.Futures.Commands.Property.AddProperty;
using RealEstateCase.Business.Futures.Commands.Property.ApproveProperty;
using RealEstateCase.Business.Futures.Commands.Property.DeleteProperty;
using RealEstateCase.Business.Futures.Queries.Property.GetAllProperty;
using RealEstateCase.Core.Controllers;

namespace RealEstateCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : BaseController
    {
        public PropertyController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddProperty([FromBody] AddPropertyCommandRequestModel requestModel, CancellationToken cancellationToken)
           => HandleResponse(await _mediator.Send(requestModel, cancellationToken));

        [HttpGet]
        public async Task<IActionResult> GetPropertyList([FromQuery] GetAllPropertyQueryRequestModel requestModel, CancellationToken cancellationToken)
            => HandleResponse(await _mediator.Send(requestModel, cancellationToken));

        [HttpDelete("{PropertyId}")]
        public async Task<IActionResult> DeleteProperty(int PropertyId, CancellationToken cancellationToken)
        {
            var requestModel = new DeletePropertyCommandRequestModel { PropertyId = PropertyId };
            return HandleResponse(await _mediator.Send(requestModel, cancellationToken));
        }

        [HttpPut("SetAdvertisementStatus")]
        public async Task<IActionResult> ApproveProperty([FromBody] SetAdvertisementStatusCommandRequestModel requestModel, CancellationToken cancellationToken)
            => HandleResponse(await _mediator.Send(requestModel, cancellationToken));


    }
}
