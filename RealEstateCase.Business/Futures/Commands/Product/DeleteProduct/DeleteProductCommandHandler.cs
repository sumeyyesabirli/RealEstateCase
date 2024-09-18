using AutoMapper;
using MediatR;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateCase.Business.Futures.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequestModel, BaseResponseModel<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel<bool>> Handle(DeleteProductCommandRequestModel request, CancellationToken cancellationToken)
        {
            var product = _unitOfWork.Repository<IProductRepository>().Query()
                              .FirstOrDefault(p => p.Id == request.ProductId);

            if (product == null)
            {
                return ResponseManager.BadRequest<bool>("Ürün bulunamadı.");
            }
            _unitOfWork.Repository<IProductRepository>().Delete(product);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
 
            if (result.Success)
            {
                _unitOfWork.Commit();
                return ResponseManager.Ok(true, "Ürün başarıyla silindi.");
            }
            else 
            {
                _unitOfWork.Rollback();
                return ResponseManager.BadRequest<bool>("Ürün silinirken bir hata oluştu.");
            }
        }
    }
}
