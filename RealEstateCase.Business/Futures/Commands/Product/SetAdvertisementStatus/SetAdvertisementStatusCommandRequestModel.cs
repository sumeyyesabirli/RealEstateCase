using MediatR;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.Entity.Enums;

namespace RealEstateCase.Business.Futures.Commands.Product.ApproveProperty
{
    public class SetAdvertisementStatusCommandRequestModel : IRequest<BaseResponseModel<bool>>
    {
        public int ProductId { get; set; }
        public AdvertisementStatusEnum Status { get; set; }
    }
}
