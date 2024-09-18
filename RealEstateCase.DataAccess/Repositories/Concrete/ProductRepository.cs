using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    internal class ProductRepository : Repository<Product, RealEstateCaseDbContext>, IProductRepository
    {
        public ProductRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}
