using AutoMapper;
using Azure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.Business.Futures.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequestModel, BaseResponseModel<IEnumerable<GetAllProductQueryResponseModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel<IEnumerable<GetAllProductQueryResponseModel>>> Handle(GetAllProductQueryRequestModel request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<IProductRepository>().Query().Include(x => x.ProductDetails).ToListAsync(cancellationToken);
            var mappedData = _mapper.Map<List<GetAllProductQueryResponseModel>>(data);
         /*   var query = (from product in _unitOfWork.Repository<IProductRepository>().Query()
                         join details in _unitOfWork.Repository<IProductDetailsRepository>().Query()
                         on product.Id equals details.ProductId
                         select new GetAllProductQueryResponseModel
                         {
                             Id = product.Id,
                             Title = product.Title,
                             Description = product.Description,
                             ProductPrice = product.ProductPrice,
                             CategoryId = product.CategoryId,
                             UserId = product.UserId,

                             ProductDetails = new ProductDetailsCommandRequestModel
                             {
                                 Id = details.Id,
                                 Title = details.Title,
                                 Description = details.Description,
                                 Type = details.Type,
                                 Status = details.Status,
                                 Location = details.Location,
                                 Bedrooms = details.Bedrooms,
                                 Bathrooms = details.Bathrooms,
                                 Floors = details.Floors,
                                 Garages = details.Garages,
                                 Area = details.Area,
                                 Size = details.Size,
                                 SaleOrRentPrice = details.SaleOrRentPrice,
                                 BeforePriceLabel = details.BeforePriceLabel,
                                 AfterPriceLabel = details.AfterPriceLabel,
                                 CenterCooling = details.CenterCooling,
                                 Balcony = details.Balcony,
                                 PetFriendly = details.PetFriendly,
                                 Barbeque = details.Barbeque,
                                 FireAlarm = details.FireAlarm,
                                 ModernKitchen = details.ModernKitchen,
                                 Storage = details.Storage,
                                 Dryer = details.Dryer,
                                 Heating = details.Heating,
                                 Pool = details.Pool,
                                 Laundry = details.Laundry,
                                 Sauna = details.Sauna,
                                 Gym = details.Gym,
                                 Elevator = details.Elevator,
                                 DishWasher = details.DishWasher,
                                 EmergencyExit = details.EmergencyExit,
                                 Address = details.Address,
                                 Country = details.Country,
                                 City = details.City,
                                 State = details.State,
                                 ZipCode = details.ZipCode,
                                 Neighborhood = details.Neighborhood
                             }
                         });
            var products = await query.ToListAsync(cancellationToken);*/
            return ResponseManager.Ok(mappedData.AsEnumerable());
        }
    }
}
