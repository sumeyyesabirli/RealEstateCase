using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateCase.Business.Futures.Commands.Category.AddCategory;
using RealEstateCase.Business.Futures.Queries.Category.GetAllCategory;
using RealEstateCase.Core.Controllers;

namespace RealEstateCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        public CategoryController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommandRequestModel requestModel, CancellationToken cancellationToken)
            => HandleResponse(await _mediator.Send(requestModel, cancellationToken));

        [HttpGet]
        public async Task<IActionResult> GetCategoryList([FromQuery] GetAllCategoryQueryRequestModel requestModel, CancellationToken cancellationToken)
           => HandleResponse(await _mediator.Send(requestModel, cancellationToken));
    }
}
