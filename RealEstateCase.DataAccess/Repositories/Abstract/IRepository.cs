using RealEstateCase.Core.Entities;

namespace RealEstateCase.DataAccess.Repositories.Abstract
{
    public interface IRepository<TEntity> : IBaseRepository where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        IQueryable<TEntity> Query();
    }
}
