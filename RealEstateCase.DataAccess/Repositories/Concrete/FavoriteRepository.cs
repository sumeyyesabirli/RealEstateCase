using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    public class FavoriteRepository : Repository<Favorite, RealEstateCaseDbContext>, IFavoriteRepository
    {
        public FavoriteRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}
