using MediatR;
using RealEstateCase.Core.ResponseManager;

namespace RealEstateCase.Business.Futures.Commands.Category.AddCategory
{
    public class AddCategoryCommandRequestModel : IRequest<BaseResponseModel<bool>>
    {
        public string CategoryName { get; set; }
    }
}
