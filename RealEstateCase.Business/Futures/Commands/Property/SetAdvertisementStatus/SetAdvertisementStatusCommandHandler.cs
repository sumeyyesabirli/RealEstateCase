using AutoMapper;
using MediatR;
using RealEstateCase.Business.Futures.Commands.Property.ApproveProperty;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using RealEstateCase.Entity.Enums;

namespace RealEstateCase.Business.Futures.Commands.Property.ApproveProperty
{
    public class SetAdvertisementStatusCommandHandler : IRequestHandler<SetAdvertisementStatusCommandRequestModel, BaseResponseModel<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SetAdvertisementStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel<bool>> Handle(SetAdvertisementStatusCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Property = _unitOfWork.Repository<IPropertyRepository>().Query()
                                   .FirstOrDefault(p => p.Id == request.PropertyId);
           
            if (Property == null)
            {
                return ResponseManager.BadRequest<bool>("Ürün bulunamadı.");
            }
            Property.AdvertisementStatusId = (int)request.Status;
            _unitOfWork.Repository<IPropertyRepository>().Update(Property);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result.Success)
            {
                return ResponseManager.Ok(true, "Ürün başarıyla onaylandı.");
            }

            return ResponseManager.BadRequest<bool>("Ürün onaylanırken bir hata oluştu.");

        }
    }
}
