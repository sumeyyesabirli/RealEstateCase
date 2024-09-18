using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    public class UserDetailRepository : Repository<UserDetail, RealEstateCaseDbContext>, IUserDetailRepository
    {
        public UserDetailRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}
