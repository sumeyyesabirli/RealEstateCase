using MediatR;
using RealEstateCase.Core.ResponseManager;

namespace RealEstateCase.Business.Futures.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandRequestModel : IRequest<BaseResponseModel<bool>>
    {
        public int ProductId { get; set; }
    }
}
