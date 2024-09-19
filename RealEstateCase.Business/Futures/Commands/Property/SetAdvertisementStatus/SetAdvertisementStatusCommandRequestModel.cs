using MediatR;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.Entity.Enums;

namespace RealEstateCase.Business.Futures.Commands.Property.ApproveProperty
{
    public class SetAdvertisementStatusCommandRequestModel : IRequest<BaseResponseModel<bool>>
    {
        public int PropertyId { get; set; }
        public AdvertisementStatusEnum Status { get; set; }
    }
}
