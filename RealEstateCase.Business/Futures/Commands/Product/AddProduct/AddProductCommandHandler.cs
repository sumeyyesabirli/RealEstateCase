using AutoMapper;
using MediatR;
using RealEstateCase.Core.ResponseManager;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using RealEstateCase.Entity.Enums;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.Business.Futures.Commands.Product.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequestModel, BaseResponseModel<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseModel<bool>> Handle(AddProductCommandRequestModel request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Entity.Main.Product>(request);
            productEntity.AdvertisementStatusId = (int)AdvertisementStatusEnum.Pending;
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IProductRepository>().Add(productEntity);
            var saveProductResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (!saveProductResult.Success)
            {

                return ResponseManager.BadRequest<bool>("Ürün kaydedilirken hata oluştu", saveProductResult.Errors);
            }
            var productDetails = _mapper.Map<Entity.Main.ProductDetails>(request.ProductDetails);
            productDetails.ProductId = productEntity.Id;
         /*   var productDetails = new ProductDetails
            {
                ProductId = productEntity.Id,
                Title = request.ProductDetails?.Title,
                Description = request.ProductDetails?.Description,
                Type = request.ProductDetails?.Type,
                Status = request.ProductDetails?.Status,
                Location = request.ProductDetails?.Location,
                Bedrooms = request.ProductDetails?.Bedrooms ?? 0,
                Bathrooms = request.ProductDetails?.Bathrooms ?? 0,
                Floors = request.ProductDetails?.Floors ?? 0,
                Garages = request.ProductDetails?.Garages ?? 0,
                Area = request.ProductDetails?.Area ?? 0,
                Size = request.ProductDetails?.Size ?? 0,
                SaleOrRentPrice = request.ProductDetails?.SaleOrRentPrice ?? 0,
                BeforePriceLabel = request.ProductDetails?.BeforePriceLabel,
                AfterPriceLabel = request.ProductDetails?.AfterPriceLabel,
                CenterCooling = request.ProductDetails.CenterCooling,
                Balcony = request.ProductDetails.Balcony,
                PetFriendly = request.ProductDetails.PetFriendly,
                Barbeque = request.ProductDetails.Barbeque,
                FireAlarm = request.ProductDetails.FireAlarm,
                ModernKitchen = request.ProductDetails.ModernKitchen,
                Storage = request.ProductDetails.Storage,
                Dryer = request.ProductDetails.Dryer,
                Heating = request.ProductDetails.Heating,
                Pool = request.ProductDetails.Pool,
                Laundry = request.ProductDetails.Laundry,
                Sauna = request.ProductDetails.Sauna,
                Gym = request.ProductDetails.Gym,
                Elevator = request.ProductDetails.Elevator,
                DishWasher = request.ProductDetails.DishWasher,
                EmergencyExit = request.ProductDetails.EmergencyExit,
                Address = request.ProductDetails.Address,
                Country = request.ProductDetails.Country,
                City = request.ProductDetails.City,
                State = request.ProductDetails.State,
                ZipCode = request.ProductDetails.ZipCode,
                Neighborhood = request.ProductDetails.Neighborhood
            };
*/
            _unitOfWork.Repository<IProductDetailsRepository>().Add(productDetails);
            var saveProductDetailResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (!saveProductDetailResult.Success)
            {
                _unitOfWork.Rollback();
                return ResponseManager.BadRequest<bool>("Ürün detayı kaydedilirken hata oluştu", saveProductDetailResult.Errors);
            }

            _unitOfWork.Commit();
            return ResponseManager.Ok(true, "Ürün ve detayı başarıyla kaydedildi.");
        }
    }
}