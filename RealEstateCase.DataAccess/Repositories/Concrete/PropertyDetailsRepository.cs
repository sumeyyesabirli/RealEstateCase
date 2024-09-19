using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    internal class PropertyDetailsRepository : Repository<PropertyDetails, RealEstateCaseDbContext>, IPropertyDetailsRepository
    {
        public PropertyDetailsRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}
