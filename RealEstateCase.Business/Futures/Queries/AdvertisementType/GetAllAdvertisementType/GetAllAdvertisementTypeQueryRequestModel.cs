using MediatR;
using RealEstateCase.Business.Futures.Queries.Property.GetAllProperty;
using RealEstateCase.Core.ResponseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateCase.Business.Futures.Queries.AdvertisementType.GetAllAdvertisementType
{
    public class GetAllAdvertisementTypeQueryRequestModel : IRequest<BaseResponseModel<IEnumerable<GetAllAdvertisementTypeQueryResponseModel>>>
    {
    }
}
