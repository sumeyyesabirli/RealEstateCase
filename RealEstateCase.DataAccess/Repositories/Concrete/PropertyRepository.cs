using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    internal class PropertyRepository : Repository<Property, RealEstateCaseDbContext>, IPropertyRepository
    {
        public PropertyRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}
