using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    public class AdvertisementTypeRepository : Repository<AdvertisementType, RealEstateCaseDbContext>, IAdvertisementTypeRepository
    {
        public AdvertisementTypeRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}