using AutoMapper;
using Azure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.Business.Futures.Queries.Property.GetAllProperty
{
    public class GetAllPropertyQueryHandler : IRequestHandler<GetAllPropertyQueryRequestModel, BaseResponseModel<IEnumerable<GetAllPropertyQueryResponseModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPropertyQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel<IEnumerable<GetAllPropertyQueryResponseModel>>> Handle(GetAllPropertyQueryRequestModel request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<IPropertyRepository>().Query().Where(x=> x.AdvertisementStatusId == (int)request.Status).Include(x => x.PropertyDetails).ToListAsync(cancellationToken);
            var mappedData = _mapper.Map<List<GetAllPropertyQueryResponseModel>>(data);
            return ResponseManager.Ok(mappedData.AsEnumerable());
        }
    }
}
