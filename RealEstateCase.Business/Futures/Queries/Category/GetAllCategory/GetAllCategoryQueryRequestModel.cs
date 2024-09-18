using MediatR;
using RealEstateCase.Business.Futures.Queries.Product.GetAllProduct;
using RealEstateCase.Core.ResponseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateCase.Business.Futures.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryRequestModel : IRequest<BaseResponseModel<IEnumerable<GetAllCategoryQueryResponseModel>>>
    {
    }
}
