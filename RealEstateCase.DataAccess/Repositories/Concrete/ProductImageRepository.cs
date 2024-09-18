using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    public class ProductImageRepository : Repository<ProductImage, RealEstateCaseDbContext>, IProductImageRepository
    {
        public ProductImageRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}
