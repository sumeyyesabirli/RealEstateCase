using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    public class UserRoleRepository : Repository<UserRole, RealEstateCaseDbContext>, IUserRoleRepository
    {
        public UserRoleRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}
