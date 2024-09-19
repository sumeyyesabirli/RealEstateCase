using MediatR;
using RealEstateCase.Core.ResponseManager;

namespace RealEstateCase.Business.Futures.Commands.AdvertisementType.AddAdvertisementType
{
    public class AddAdvertisementTypeCommandRequestModel : IRequest<BaseResponseModel<bool>>
    {
        public string AdvertisementTypeName { get; set; }
    }
}
