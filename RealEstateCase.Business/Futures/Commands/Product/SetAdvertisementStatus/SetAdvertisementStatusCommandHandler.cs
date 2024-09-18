using AutoMapper;
using MediatR;
using RealEstateCase.Business.Futures.Commands.Product.ApproveProperty;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using RealEstateCase.Entity.Enums;

namespace RealEstateCase.Business.Futures.Commands.Product.ApproveProduct
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
            var product = _unitOfWork.Repository<IProductRepository>().Query()
                                   .FirstOrDefault(p => p.Id == request.ProductId);
           
            if (product == null)
            {
                return ResponseManager.BadRequest<bool>("Ürün bulunamadı.");
            }
            product.AdvertisementStatusId = (int)request.Status;
            _unitOfWork.Repository<IProductRepository>().Update(product);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result.Success)
            {
                return ResponseManager.Ok(true, "Ürün başarıyla onaylandı.");
            }

            return ResponseManager.BadRequest<bool>("Ürün onaylanırken bir hata oluştu.");

        }
    }
}
