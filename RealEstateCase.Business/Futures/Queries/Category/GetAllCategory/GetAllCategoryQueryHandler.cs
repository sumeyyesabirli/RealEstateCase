using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;

namespace RealEstateCase.Business.Futures.Queries.Category.GetAllCategory
{
    internal class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequestModel, BaseResponseModel<IEnumerable<GetAllCategoryQueryResponseModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel<IEnumerable<GetAllCategoryQueryResponseModel>>> Handle(GetAllCategoryQueryRequestModel request, CancellationToken cancellationToken)
        {
            var query = (from category in _unitOfWork.Repository<ICategoryRepository>().Query()
                         select new GetAllCategoryQueryResponseModel
                         {
                             CategoryName = category.CategoryName
                         });

            var categorys = await query.ToListAsync(cancellationToken);
            return ResponseManager.Ok(categorys.AsEnumerable());
        }
    }
}
