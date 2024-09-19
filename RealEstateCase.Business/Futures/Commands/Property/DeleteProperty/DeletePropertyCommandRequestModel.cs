using MediatR;
using RealEstateCase.Core.ResponseManager;

namespace RealEstateCase.Business.Futures.Commands.Property.DeleteProperty
{
    public class DeletePropertyCommandRequestModel : IRequest<BaseResponseModel<bool>>
    {
        public int PropertyId { get; set; }
    }
}
