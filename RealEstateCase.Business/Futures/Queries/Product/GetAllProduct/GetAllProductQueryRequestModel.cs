using MediatR;
using RealEstateCase.Core.ResponseManager;

namespace RealEstateCase.Business.Futures.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryRequestModel : IRequest<BaseResponseModel<IEnumerable<GetAllProductQueryResponseModel>>>
    {
    }
}
