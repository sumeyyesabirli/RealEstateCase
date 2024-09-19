using AutoMapper;
using MediatR;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateCase.Business.Futures.Commands.Property.DeleteProperty
{
    public class DeletePropertyCommandHandler : IRequestHandler<DeletePropertyCommandRequestModel, BaseResponseModel<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePropertyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel<bool>> Handle(DeletePropertyCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Property = _unitOfWork.Repository<IPropertyRepository>().Query()
                              .FirstOrDefault(p => p.Id == request.PropertyId);

            if (Property == null)
            {
                return ResponseManager.BadRequest<bool>("Ürün bulunamadı.");
            }
            _unitOfWork.Repository<IPropertyRepository>().Delete(Property);
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
