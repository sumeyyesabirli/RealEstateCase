using AutoMapper;

namespace RealEstateCase.Business.Futures.Commands.AdvertisementType.AddAdvertisementType
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddAdvertisementTypeCommandRequestModel, Entity.Main.AdvertisementType>();
        }
    }
}
