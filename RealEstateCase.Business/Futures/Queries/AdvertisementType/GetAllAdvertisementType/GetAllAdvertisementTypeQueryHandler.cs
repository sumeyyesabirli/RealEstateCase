using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;

namespace RealEstateCase.Business.Futures.Queries.AdvertisementType.GetAllAdvertisementType
{
    internal class GetAllAdvertisementTypeQueryHandler : IRequestHandler<GetAllAdvertisementTypeQueryRequestModel, BaseResponseModel<IEnumerable<GetAllAdvertisementTypeQueryResponseModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAdvertisementTypeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel<IEnumerable<GetAllAdvertisementTypeQueryResponseModel>>> Handle(GetAllAdvertisementTypeQueryRequestModel request, CancellationToken cancellationToken)
        {
            var query = (from AdvertisementType in _unitOfWork.Repository<IAdvertisementTypeRepository>().Query()
                         select new GetAllAdvertisementTypeQueryResponseModel
                         {
                             AdvertisementTypeName = AdvertisementType.AdvertisementTypeName
                         });

            var AdvertisementTypes = await query.ToListAsync(cancellationToken);
            return ResponseManager.Ok(AdvertisementTypes.AsEnumerable());
        }
    }
}
