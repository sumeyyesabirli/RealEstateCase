using AutoMapper;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.Business.Futures.Commands.Register.AddRegister
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddRegisterCommandRequestModel, User>();
        }
    }
}
