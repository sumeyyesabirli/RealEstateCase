using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    public class UserRepository : Repository<User, RealEstateCaseDbContext>, IUserRepository
    {
        public UserRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}
