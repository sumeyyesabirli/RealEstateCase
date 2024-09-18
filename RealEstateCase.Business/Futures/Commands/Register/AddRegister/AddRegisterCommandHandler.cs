using AutoMapper;
using MediatR;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.Business.Futures.Commands.Register.AddRegister
{
    public class AddRegisterCommandHandler : IRequestHandler<AddRegisterCommandRequestModel, BaseResponseModel<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddRegisterCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseModel<bool>> Handle(AddRegisterCommandRequestModel request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<User>(request);
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IUserRepository>().Add(entity);

            var saveResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (saveResult.Success)
            {
                _unitOfWork.Commit();
                return ResponseManager.Ok(saveResult.Success, "Kişi oluşturuldu");
            }
            else
            {
                _unitOfWork.Rollback();
                return ResponseManager.BadRequest<bool>("Kişi kaydedilirken hata oluştu", saveResult.Errors);
            }
        }
    }
}
