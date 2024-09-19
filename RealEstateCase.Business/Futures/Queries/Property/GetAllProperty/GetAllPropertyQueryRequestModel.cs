using MediatR;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.Entity.Enums;

namespace RealEstateCase.Business.Futures.Queries.Property.GetAllProperty
{
    public class GetAllPropertyQueryRequestModel : IRequest<BaseResponseModel<IEnumerable<GetAllPropertyQueryResponseModel>>>
    {
        public AdvertisementStatusEnum? Status { get; set; }
    }
}
