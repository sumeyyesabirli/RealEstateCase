using AutoMapper;
using MediatR;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using RealEstateCase.Entity.Enums;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.Business.Futures.Commands.Property.AddProperty
{
    public class AddPropertyCommandHandler : IRequestHandler<AddPropertyCommandRequestModel, BaseResponseModel<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddPropertyCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseModel<bool>> Handle(AddPropertyCommandRequestModel request, CancellationToken cancellationToken)
        {
            var PropertyEntity = _mapper.Map<Entity.Main.Property>(request);
            PropertyEntity.AdvertisementStatusId = (int)AdvertisementStatusEnum.Pending;
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IPropertyRepository>().Add(PropertyEntity);
            var savePropertyResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (!savePropertyResult.Success)
            {

                return ResponseManager.BadRequest<bool>("Ürün kaydedilirken hata oluştu", savePropertyResult.Errors);
            }
            var PropertyDetails = _mapper.Map<Entity.Main.PropertyDetails>(request.PropertyDetails);
            PropertyDetails.PropertyId = PropertyEntity.Id;
         
            _unitOfWork.Repository<IPropertyDetailsRepository>().Add(PropertyDetails);
            var savePropertyDetailResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (!savePropertyDetailResult.Success)
            {
                _unitOfWork.Rollback();
                return ResponseManager.BadRequest<bool>("Ürün detayı kaydedilirken hata oluştu", savePropertyDetailResult.Errors);
            }

            _unitOfWork.Commit();
            return ResponseManager.Ok(true, "Ürün ve detayı başarıyla kaydedildi.");
        }
    }
}