using AutoMapper;

namespace RealEstateCase.Business.Futures.Commands.Property.AddProperty
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddPropertyCommandRequestModel, Entity.Main.Property>();

            CreateMap<PropertyDetailsCommandRequestModel, Entity.Main.PropertyDetails>();

            //CreateMap<AddPropertyImageCommandRequestModel, Entity.Main.PropertyImage>();
        }
    }
}
