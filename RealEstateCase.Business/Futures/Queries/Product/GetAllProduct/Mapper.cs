using AutoMapper;

namespace RealEstateCase.Business.Futures.Queries.Product.GetAllProduct
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entity.Main.Product, GetAllProductQueryResponseModel>();

            CreateMap<Entity.Main.ProductDetails, ProductDetailsQueryResponseModel>();
        }
    }
}
