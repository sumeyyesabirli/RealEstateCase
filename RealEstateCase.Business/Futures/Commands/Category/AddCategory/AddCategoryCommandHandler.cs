using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateCase.Business.Futures.Commands.Category.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequestModel, BaseResponseModel<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ILogger<AddCategoryCommandHandler> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponseModel<bool>> Handle(AddCategoryCommandRequestModel request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Entity.Main.Category>(request);
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<ICategoryRepository>().Add(entity);

            var saveResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (saveResult.Success)
            {
                _unitOfWork.Commit();

                return ResponseManager.Ok(saveResult.Success, "Kategori oluşturuldu");
            }
            else
            {
                _unitOfWork.Rollback();
                return ResponseManager.BadRequest<bool>("Kategori kaydedilirken hata oluştu", saveResult.Errors);
            }
        }
    }
}
