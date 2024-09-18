﻿using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Repositories.Concrete
{
    public class CategoryRepository : Repository<Category, RealEstateCaseDbContext>, ICategoryRepository
    {
        public CategoryRepository(RealEstateCaseDbContext context) : base(context)
        {
        }
    }
}
