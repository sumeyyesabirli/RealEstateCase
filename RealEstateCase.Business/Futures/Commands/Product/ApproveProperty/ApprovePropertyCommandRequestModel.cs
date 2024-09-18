using MediatR;
using RealEstateCase.Core.ResponseManager;

namespace RealEstateCase.Business.Futures.Commands.Product.ApproveProperty
{
    public class ApprovePropertyCommandRequestModel : IRequest<BaseResponseModel<bool>>
    {
        public int ProductId { get; set; }
    }
}
