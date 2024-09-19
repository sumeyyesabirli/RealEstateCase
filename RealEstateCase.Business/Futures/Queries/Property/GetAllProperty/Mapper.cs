using AutoMapper;

namespace RealEstateCase.Business.Futures.Queries.Property.GetAllProperty
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entity.Main.Property, GetAllPropertyQueryResponseModel>();

            CreateMap<Entity.Main.PropertyDetails, PropertyDetailsQueryResponseModel>();
        }
    }
}
