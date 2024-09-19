using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    public class PropertyImageRepository : Repository<PropertyImage, RealEstateCaseDbContext>, IPropertyImageRepository
    {
        public PropertyImageRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}
