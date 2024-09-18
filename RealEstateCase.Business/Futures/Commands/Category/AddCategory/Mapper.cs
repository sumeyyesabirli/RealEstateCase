using AutoMapper;

namespace RealEstateCase.Business.Futures.Commands.Category.AddCategory
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddCategoryCommandRequestModel, Entity.Main.Category>();
        }
    }
}
