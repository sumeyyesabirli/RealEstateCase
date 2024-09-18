using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    internal class ProductDetailsRepository : Repository<ProductDetails, RealEstateCaseDbContext>, IProductDetailsRepository
    {
        public ProductDetailsRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}
