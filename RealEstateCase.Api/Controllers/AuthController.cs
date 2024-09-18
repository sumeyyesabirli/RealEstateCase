using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateCase.Business.Futures.Commands.Register.AddRegister;
using RealEstateCase.Core.Controllers;

namespace RealEstateCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddRegisterCommandRequestModel requestModel, CancellationToken cancellationToken)
           => HandleResponse(await _mediator.Send(requestModel, cancellationToken));
    }
}
