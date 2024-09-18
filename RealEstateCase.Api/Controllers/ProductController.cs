using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateCase.Business.Futures.Commands.Product.AddProduct;
using RealEstateCase.Business.Futures.Commands.Product.ApproveProperty;
using RealEstateCase.Business.Futures.Commands.Product.DeleteProduct;
using RealEstateCase.Business.Futures.Queries.Product.GetAllProduct;
using RealEstateCase.Core.Controllers;

namespace RealEstateCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommandRequestModel requestModel, CancellationToken cancellationToken)
           => HandleResponse(await _mediator.Send(requestModel, cancellationToken));

        [HttpGet]
        public async Task<IActionResult> GetProductList([FromQuery] GetAllProductQueryRequestModel requestModel, CancellationToken cancellationToken)
            => HandleResponse(await _mediator.Send(requestModel, cancellationToken));

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            var requestModel = new DeleteProductCommandRequestModel { ProductId = productId };
            return HandleResponse(await _mediator.Send(requestModel, cancellationToken));
        }

        [HttpPut("api/Product/Approve/{id}")]
        public async Task<IActionResult> ApproveProduct(int id, CancellationToken cancellationToken)
        {
            var requestModel = new ApprovePropertyCommandRequestModel
            {
                ProductId = id
            };

            return HandleResponse(await _mediator.Send(requestModel, cancellationToken));
        }

    }
}
