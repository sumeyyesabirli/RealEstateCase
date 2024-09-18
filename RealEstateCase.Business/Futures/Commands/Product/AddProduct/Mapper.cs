using AutoMapper;

namespace RealEstateCase.Business.Futures.Commands.Product.AddProduct
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddProductCommandRequestModel, Entity.Main.Product>();

            CreateMap<ProductDetailsCommandRequestModel, Entity.Main.ProductDetails>();

            //CreateMap<AddProductImageCommandRequestModel, Entity.Main.ProductImage>();
        }
    }
}
