using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    public class RoleRepository : Repository<Role, RealEstateCaseDbContext>, IRoleRepository
    {
        public RoleRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}
