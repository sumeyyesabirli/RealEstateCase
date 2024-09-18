using MediatR;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.Entity.Enums;

namespace RealEstateCase.Business.Futures.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryRequestModel : IRequest<BaseResponseModel<IEnumerable<GetAllProductQueryResponseModel>>>
    {
        public AdvertisementStatusEnum Status { get; set; }
    }
}
