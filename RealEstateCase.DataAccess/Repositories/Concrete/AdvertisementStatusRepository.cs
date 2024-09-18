using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    public class AdvertisementStatusRepository : Repository<AdvertisementStatus, RealEstateCaseDbContext>, IAdvertisementStatusRepository
    {
        public AdvertisementStatusRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}
